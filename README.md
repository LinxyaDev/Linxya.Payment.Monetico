# Linxya.Payment.Monetico
C# Library for Monetico Payment in Asp.Net Core (.Net 6)

This NuGet package is used in a payment plugin for GrandNode2, an opensource ecommerce solution.

# Usage example
## Payment request

```csharp
                // Create the order context for the payment request
                var context = new OrderContext(
                   new OrderContextBilling(
                        order.BillingAddress.Address1,
                        order.BillingAddress.City,
                        order.BillingAddress.ZipPostalCode,
                        billingCountry?.TwoLetterIsoCode
                        ) {
                       //Address = ,
                       //AddressLine2 = ,
                       //AddressLine3 = ,
                       //CountrySubdivision = ,
                       //HomePhone = ,
                       //WorkPhone = ,
                       //MiddleName = ,
                       //MobilePhone = ,
                       //Name = ,
                       //StateOrProvince = ,
                       Civility = billingCivility,
                       FirstName = order.BillingAddress.FirstName,
                       LastName = order.BillingAddress.LastName,
                       Email = order.BillingAddress.Email,
                       Phone = order.BillingAddress.PhoneNumber
                   }) {
                    Client = new OrderContextClient() {
                        //MiddleName = ,
                        //LastPasswordChange = ,
                        //AccountAge = ,
                        //AddCardNbLast24Hours = ,
                        //Address = ,
                        //AddressLine1 = ,
                        //AddressLine2 = ,
                        //AddressLine3 = ,
                        //AuthenticationMethod = ,
                        //BirthCity = ,
                        //BirthCountry = ,
                        //BirthCountrySubdivision = ,
                        //Birthdate = ,
                        //BirthLastName = ,
                        //BirthPostalCode = ,
                        //BirthStateOrProvince = ,
                        //CountrySubdivision = ,
                        //Last24HoursTransactions = ,
                        //Last6MonthsPurchase = ,
                        //LastYearTransactions = ,
                        //Name = ,
                        //NationalIDNumber = ,
                        //PaymentMeanAge = ,
                        //PriorAuthenticationMethod = ,
                        //PriorAuthenticationTimestamp = ,
                        //SuspiciousAccountActivity = ,
                        //StateOrProvince = ,
                        City = order.BillingAddress.City,
                        Country = billingCountry?.TwoLetterIsoCode,
                        PostalCode = order.BillingAddress.ZipPostalCode,
                        Civility = customerCivility,
                        FirstName = order.BillingAddress.FirstName,
                        LastName = order.BillingAddress.LastName,
                        Email = order.BillingAddress.Email,
                        Phone = order.BillingAddress.PhoneNumber,
                        LastAccountModification = customer.LastActivityDateUtc,
                        AuthenticationTimestamp = DateTime.Now.AddMinutes(-5)
                    },
                    Shipping = order.ShippingAddress == null ? null : new OrderContextShipping() {
                        //Address = ,
                        //AddressLine1 = ,
                        //AddressLine2 = ,
                        //AddressLine3 = ,
                        //CountrySubdivision = ,
                        //DeliveryTimeframe = ,
                        //FirstUseDate = ,
                        //MatchBillingAddress = ,
                        //Name = ,
                        //ShipIndicator = ,
                        //StateOrProvince = ,
                        City = order.ShippingAddress.City,
                        Country = shippingCountry?.TwoLetterIsoCode,
                        PostalCode = order.ShippingAddress.ZipPostalCode,
                        Civility = shippingCivility,
                        FirstName = order.ShippingAddress.FirstName,
                        LastName = order.ShippingAddress.LastName,
                        Email = order.ShippingAddress.Email,
                        Phone = order.ShippingAddress.PhoneNumber
                    },
                    //ShoppingCart = new OrderContextShoppingCart() {
                    //    //GiftCardAmount = ,
                    //    //GiftCardCurrency = ,
                    //    //GiftCardCount = ,
                    //    //PreOrderDate = ,
                    //    //PreorderIndicator = ,
                    //    //ReorderIndicator = ,
                    //    ShoppingCartItems = order.OrderItems.Select(item => new OrderContextShoppingCartItem() {
                    //        //Name = ,
                    //        //Description = ,
                    //        //ImageURL = ,
                    //        //ProductCode = ,
                    //        //ProductRisk = ,
                    //        //ProductSKU = ,
                    //        Quantity = item.Quantity,
                    //        UnitPrice = Convert.ToInt32(item.UnitPriceInclTax)
                    //    })
                    //}
                };

                // Create a new payment request
                // Use this object to retrieve the form fields that must be included
                // when calling the payment page including the computed seal
                var paymentRequest = new MoneticoPaymentRequest(
                    _moneticoPaymentSettings,
                    order.Id, //$"{paymentTransaction.OrderCode}-{paymentTransaction.Id}",
                    Convert.ToDecimal(paymentTransaction.TransactionAmount), //123.45M,
                    order.CustomerCurrencyCode,
                    customerLanguage?.UniqueSeoCode,
                    context
                ) {
                    //TexteLibre = "Do not forget to HTML-encode every field value otherwise special characters might cause issues",
                    // User return after success payment
                    UrlRetourOk = new Uri($"{SITE_URL}/ConfirmOrder/{order.OrderGuid}"),
                    // User cancel
                    UrlRetourErreur = new Uri($"{SITE_URL}/CancelOrder/{order.OrderGuid}")
                };

                // Bypass 3DSecure option if possible
                if (!_moneticoPaymentSettings.Use3DS)
                {
                    paymentRequest.ThreeDSecureChallenge = AuthThreeDSecurePreference.NoChallengeRequested;
                }

                //create common query parameters for the request
                var queryParameters = paymentRequest.GetFormFields();

                var url = QueryHelpers.AddQueryString(_moneticoPaymentSettings.PayementUrl, queryParameters);
                // Call the get request
                _httpContextAccessor.HttpContext.Response.Redirect(url);
                
```
## Payment response from Monetico
Note: the url is set in the user interface of Monetico.

```csharp
        [HttpGet]
        public async Task<string> SuccessOrderGet([FromQuery] MoneticoResponse responseModel)
        {
            responseModel.AllData = Request.Query.ToDictionary(k => k.Key, k => k.Value.ToString());
            return await ProcessOrder(responseModel);
        }

        [HttpPost]
        public async Task<string> SuccessOrderPost([FromForm] MoneticoResponse responseModel)
        {
            responseModel.AllData = Request.Form.ToDictionary(k => k.Key, k => k.Value.ToString());
            return await ProcessOrder(responseModel);
        }

        /// <summary>
        /// Log errors + if needed, write an order note
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="moneticoResponse"></param>
        /// <param name="order"></param>
        /// <returns>Error number</returns>
        private async Task<int> ProcessError(string errorMessage, StringBuilder moneticoResponse = null, Order order = null)
        {
            // LOG THE ERROR
            /////await _logger.Error(errorMessage);
            if (order != null && moneticoResponse != null)
            {
                moneticoResponse.AppendLine(errorMessage);
                // WRITE THE NOTE IN THE ORDER
                //[...]
            }
            return 1;
        }

        private async Task<string> ProcessOrder(MoneticoResponse responseModel)
        {
            // By default: success infos
            (int version, int cdr, string infos) returnValue = (2, 0 , null);

            var moneticoResponse = new StringBuilder();
            moneticoResponse.AppendLine("Monetico response:");
            responseModel.AllData.ForEach(data => moneticoResponse.AppendLine($"{data.Key}: {data.Value}"));

            // Fields can be provided by both GET or POST method. This is due to the fact that the 
            // Monetico system uses the POST method. If the response interface returns an error, a mail is sent with
            // a link to the response interface with all payments parameters. Clicking this link will trigger a GET request
            // to the response interface.
            // Therefore, you must be capable to handle a response interface request being it sent through GET or POST method.

            // Test if Reference empty
            if (!string.IsNullOrWhiteSpace(responseModel.Reference))
            {
                // TRY TO GET THE ORDER
                ///////Order order = [...];
                // Test if order found
                if (order != null)
                {
                    // Test if error MAC invalid or TPE invalid or montant invalid or code-retour invalid
                    if (!string.IsNullOrWhiteSpace(responseModel.Mac) &&
                        !string.IsNullOrWhiteSpace(responseModel.Tpe) &&
                        string.Compare(responseModel.Tpe, _moneticoPaymentSettings.Tpe) == 0 &&
                        new HmacComputer().ValidateSeal(responseModel.AllData, _moneticoPaymentSettings.MacKey, responseModel.Mac) &&
                        responseModel.Montant.HasValue &&
                        responseModel.CodeRetour.HasValue
                        )
                    {
                        var paymentTransaction = await _paymentTransactionService.GetOrderByGuid(order.OrderGuid);

                        // Test if order total invalid
                        if (Math.Round(order.OrderTotal, 2).Equals((double)Math.Round(responseModel.Montant.Value, 2)))
                        {
                            await WriteOrderNote(moneticoResponse, order);

                            switch (responseModel.CodeRetour.Value)
                            {

                                case CodeRetourEnum.Annulation:
                                    /* 
                                    * Payment has been refused
                                    * Attention : an authorization may still be delivered later
                                    */
                                    // DO THE CANCEL PAYMENT
                                    // [...]
                                    break;

                                case CodeRetourEnum.PayeTest:
                                /*
                                * Payment has been accepted on the test server
                                * put your code here (email sending / Database update)
                                */
                                //                                    break;
                                case CodeRetourEnum.Paiement:
                                    // DO THE PAYMENT
                                    // [...]
                                    break;

                                /*** ONLY FOR MULTIPART PAYMENT ***/
                                case CodeRetourEnum.PaiementPf2:
                                case CodeRetourEnum.PaiementPf3:
                                case CodeRetourEnum.PaiementPf4:
                                    /*
                                    * Payment has been accepted on the productive server for the part #N
                                    * return code is like paiement_pf[#N]
                                    * put your code here (email sending / Database update)
                                    * You have the amount of the payment part in MontantEch
                                    */
                                    break;

                                case CodeRetourEnum.AnnulationPf2:
                                case CodeRetourEnum.AnnulationPf3:
                                case CodeRetourEnum.AnnulationPf4:
                                    /*
                                    * Payment has been refused on the productive server for the part #N
                                    * return code is like Annulation_pf[#N]
                                    * put your code here (email sending / Database update)
                                    * You have the amount of the payment part in MontantEch
                                    */
                                    break;
                            }
                        }
                        else
                        {
                            // Order total invalid
                            returnValue.cdr = await ProcessError($"Monetico response. Returned order total {responseModel.Montant.Value} doesn't equal order total {order.OrderTotal}", moneticoResponse, order);
                        }
                    }
                    else
                    {
                        // Error MAC invalid or TPE invalid or montant invalid or code-retour invalid
                        returnValue.cdr = await ProcessError("Monetico error: MAC, TPE, montant or code-retour invalid", moneticoResponse, order);
                        // Only for debug!!!! 
                        //returnValue.infos = new HmacComputer().SealFields(responseModel.AllData, _moneticoPaymentSettings.MacKey);
                    }
                }
                else
                {
                    // Order is null
                    returnValue.cdr = await ProcessError("Monetico error: order not found");
                }
            }
            else
            {
                // Reference empty
                returnValue.cdr = await ProcessError("Monetico error: reference empty");
            }
            return $"version={returnValue.version}{Environment.NewLine}cdr={returnValue.cdr}{(string.IsNullOrWhiteSpace(returnValue.infos) ? "" : $"{Environment.NewLine}{returnValue.infos}")}";
        }
```

## User return after payment or for cancelation

```csharp
        [HttpGet]
        public async Task<IActionResult> ConfirmOrder(Guid orderRef)
        {
            // TRY TO GET THE ORDER
            ////Order order = [...];
            if (order != null)
            {
                return RedirectToRoute("CheckoutCompleted", new { orderId = order.Id, vendorid = order.StoreId });
            }
            return RedirectToRoute("HomePage");
        }
        [HttpGet]
        public async Task<IActionResult> CancelOrder(Guid orderRef)
        {
            // TRY TO GET THE ORDER
            ////Order order = [...];
            if (order != null)
            {
                // DO THE ORDER CANCELATION
                //[...]
                return RedirectToRoute("OrderDetails", new { orderId = order.Id });
            }

            return RedirectToRoute("HomePage");
        }
```
