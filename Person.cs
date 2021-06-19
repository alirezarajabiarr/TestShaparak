using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestShaparak.Extention;
using TestShaparak.Models;
using TestShaparak.SingletonWrapper;

namespace TestShaparak
{
    public class Person : SingletonWrapper<Person>
    {
        public List<ShaparakRequest> FillAllDatamain()
        {
            try
            {
                var birthDate = PersionDateToTimeSpan("1363/12/07");
                var registerDate = PersionDateToTimeSpan("1400/01/30");//tarigh sabt hoghoghi
                var ContarctDate = DateToTimeSpan(DateTime.Now);//tarigh sabt hoghoghi
                var datenow = DateToTimeSpan(DateTime.Now);
                var acceptorCodePspPerMerchat = "000000900000001";
                var seq = DateToTimeSpan(DateTime.Now);
                var terminalNumberPspPerMercha = "47725001";
                var iban = "IR650120010000001944941402";//IR110190000000326787748005//"IR500190000000323721603008"//"IR260190000000114808870000";//"IR880560085602002134463001";
                var iin = "581672121";
                var postalCode = "1516714414";
                var nationalCode = "0061100722";

                var result = new ShaparakRequest
                {
                    trackingNumberPsp = Guid.NewGuid().ToString(),
                    //Description = null,
                    relatedMerchants = null,
                    requestType = RequstTypeEnum.DefineMerchant,
                    merchant = new Merchant()
                    {
                        //M mandetory
                        //O optional
                        //R haghighi
                        //H hoghoghi
                        firstNameFa = "علیرضا",//M R
                        lastNameFa = "رجبی",//M R
                        fatherNameFa = "صادق",//M R
                        firstNameEn = "alireza",//O
                        lastNameEn = "rajabi",//O
                        fatherNameEn = "sadegh",//O
                        gender = GenderEnum.Man,//M R
                        birthDate = birthDate,//M R
                        //registerDate = registerDate//M H 
                        nationalCode = nationalCode,//M R
                        comNameFa = "تمدن",//M H
                        comNameEn = "tamadonpay",//O
                        merchantType = MerchantTypeEnum.Haghighi,//M
                        residencyType = ResidencyTypeEnum.Irani,//M
                        vitalStatus = VitalStatusEnum.Yes,
                        //nationalLegalCode = "101010",//M H //شناسه ملی اشخاص حقوقی
                        // countryCode = "IR",//
                        // foreignPervasiveCode = "",//M R//code atba
                        passportNumber = null,//M R//code atba
                        passportExpireDate = null, //M R//code atba
                        telephoneNumber = "021-44589814", //M
                        cellPhoneNumber = "09363068269",//M
                        merchantIbans = new List<MerchantIban> { new MerchantIban { merchantIban = iban } },

                    },

                    contract = new Contract
                    {
                        contractDate = ContarctDate,
                        serviceStartDate = ContarctDate,

                        contractNumber = "101255",//M //shomareh 



                    },
                    //pspRequestShopAcceptors =new List<ShopAcceptor> { new ShopAcceptor { acceptors = } }
                    pspRequestShopAcceptors = new List<ShopAcceptor>()
                    {
                        new ShopAcceptor
                        {
                            acceptors = new List<Acceptor>
                        {
                            new Acceptor
                            {
                                iin = iin,//?
                                acceptorCode = acceptorCodePspPerMerchat,//az psp
                                acceptorType = AcceptorTypeEnum.All,
                                facilitatorAcceptorCode = "100000048825000",//code acceptor ma//000000900000001
                                shaparakSettlementIbans = new List<string>{ iban },
                                terminals =new List<Terminal>
                                {
                                    new Terminal
                                    {
                                        sequence = seq,//uniqe
                                        terminalNumber = terminalNumberPspPerMercha,
                                        terminalType = TerminalTypeEnum.Ipg,
                                        setupDate = datenow,
                                        accessAddress = "https://tamadonpay.com",
                                        accessPort = 80,
                                        callbackAddress = "https://tamadonpay.com",
                                        callbackPort = 80,

                                    }
                                },
                                allowAmericanExpressTrx = true,
                                allowFoodSecurityTrx = true,
                                allowGoodsBasketTrx = true,
                                allowIranianProductsTrx = true,
                                allowJcbCardTrx = true,
                                allowKaraCardTrx = true,
                                allowMasterCardTrx = true,
                                allowOtherInternationaCardsTrx = true,
                                allowVisaCardTrx = true,
                                blockable = true,
                                cancelable = true,
                                chargeBackable = true,
                                allowUpiCardTrx = true,
                                allowScatteredSettlement = AllowScatteredSettlementEnum.NoTaghsimVajh,
                            }
                        },
                            shop = new Shop
                        {
                            farsiName = "فروشگاه تستی1",
                            englishName = "test shop",
                            telephoneNumber = "021-44589814",
                            postalCode = postalCode,
                            businessCategoryCode = "5812",
                            businessSubCategoryCode = "0",
                            countryCode = "IR",// just Ir
                            businessType = BusinessTypeEnum.FisikiMajazi,
                            websiteAddress = "https://tamadonpay.com",
                            emailAddress = "tamadonpay@gmail.com",
                            taxPayerCode = "1234567891",
                        }
                        }
                    }
                };
                var listResult = new List<ShaparakRequest>
                {
                    result
                };
                return listResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public List<ShaparakRequest> FillAllDatamainChange()
        {
            try
            {
                var birthDate = PersionDateToTimeSpan("1363/12/07");
                var registerDate = PersionDateToTimeSpan("1400/01/30");//tarigh sabt hoghoghi
                var ContarctDate = DateToTimeSpan(DateTime.Now);//tarigh sabt hoghoghi
                var datenow = DateToTimeSpan(DateTime.Now);
                var acceptorCodePspPerMerchat = "000000900000001";
                var seq = DateToTimeSpan(DateTime.Now);
                var terminalNumberPspPerMercha = "47725001";
                var iban = "IR880560085602002134463001";//IR110190000000326787748005//"IR500190000000323721603008"//"IR260190000000114808870000";//"IR880560085602002134463001";
                var iin = "581672121";
                var postalCode = "1516714414";
                var nationalCode = "0061100722";

                var result = new ShaparakRequest
                {
                    trackingNumberPsp = Guid.NewGuid().ToString(),
                    //Description = null,
                    relatedMerchants = null,
                    requestType = RequstTypeEnum.DefineMerchant,
                    merchant = new Merchant()
                    {
                        //M mandetory
                        //O optional
                        //R haghighi
                        //H hoghoghi
                        firstNameFa = "علیرضا",//M R
                        lastNameFa = "رجبی",//M R
                        fatherNameFa = "صادق",//M R
                        firstNameEn = "alireza",//O
                        lastNameEn = "rajabi",//O
                        fatherNameEn = "sadegh",//O
                        gender = GenderEnum.Man,//M R
                        birthDate = birthDate,//M R
                        //registerDate = registerDate//M H 
                        nationalCode = nationalCode,//M R
                        comNameFa = "تمدن",//M H
                        comNameEn = "tamadonpay",//O
                        merchantType = MerchantTypeEnum.Haghighi,//M
                        residencyType = ResidencyTypeEnum.Irani,//M
                        vitalStatus = VitalStatusEnum.Yes,
                        //nationalLegalCode = "101010",//M H //شناسه ملی اشخاص حقوقی
                        // countryCode = "IR",//
                        // foreignPervasiveCode = "",//M R//code atba
                        passportNumber = null,//M R//code atba
                        passportExpireDate = null, //M R//code atba
                        telephoneNumber = "021-44589814", //M
                        cellPhoneNumber = "09363068269",//M
                        merchantIbans = new List<MerchantIban> { new MerchantIban { merchantIban = iban } },

                    },

                    contract = new Contract
                    {
                        contractDate = ContarctDate,
                        serviceStartDate = ContarctDate,
                        contractNumber = "101255",//M //shomareh 
                    },
                    //pspRequestShopAcceptors =new List<ShopAcceptor> { new ShopAcceptor { acceptors = } }
                    pspRequestShopAcceptors = new List<ShopAcceptor>()
                    {
                        new ShopAcceptor
                        {
                            acceptors = new List<Acceptor>
                        {
                            new Acceptor
                            {
                                iin = iin,//?
                                acceptorCode = acceptorCodePspPerMerchat,//az psp
                                acceptorType = AcceptorTypeEnum.All,
                                facilitatorAcceptorCode = "100000048825000",//code acceptor ma//000000900000001
                                shaparakSettlementIbans = new List<string>{ iban },
                                terminals =new List<Terminal>
                                {
                                    new Terminal
                                    {
                                        sequence = seq,//uniqe
                                        terminalNumber = terminalNumberPspPerMercha,
                                        terminalType = TerminalTypeEnum.Ipg,
                                        setupDate = datenow,
                                        accessAddress = "https://tamadonpay.com",
                                        accessPort = 80,
                                        callbackAddress = "https://tamadonpay.com",
                                        callbackPort = 80,

                                    }
                                },
                                allowAmericanExpressTrx = true,
                                allowFoodSecurityTrx = true,
                                allowGoodsBasketTrx = true,
                                allowIranianProductsTrx = true,
                                allowJcbCardTrx = true,
                                allowKaraCardTrx = true,
                                allowMasterCardTrx = true,
                                allowOtherInternationaCardsTrx = true,
                                allowVisaCardTrx = true,
                                blockable = true,
                                cancelable = true,
                                chargeBackable = true,
                                allowUpiCardTrx = true,
                                allowScatteredSettlement = AllowScatteredSettlementEnum.NoTaghsimVajh,
                            }
                        },
                            shop = new Shop
                        {
                                taxPayerCode = "1234567891",
                              farsiName = "فروشگاه دوم",
                    englishName = "secend shop",
                    telephoneNumber = "021-44589814",
                    postalCode = postalCode,
                    businessCategoryCode = "5812",
                    businessSubCategoryCode = "0",
                    countryCode = "IR",// just Ir
                    businessType = BusinessTypeEnum.FisikiMajazi,
                    websiteAddress = "https://faraboom.com",
                    emailAddress = "faraboom2@gmail.com",
                        }
                        }
                    }
                };
                var listResult = new List<ShaparakRequest>
                {
                    result
                };
                return listResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public List<ShaparakRequest> FillAllData2()
        {
            try
            {
                var birthDate = PersionDateToTimeSpan("1363/12/07");
                var registerDate = PersionDateToTimeSpan("1400/01/30");//tarigh sabt hoghoghi
                var ContarctDate = DateToTimeSpan(DateTime.Now);//tarigh sabt hoghoghi
                var datenow = DateToTimeSpan(DateTime.Now);
                var acceptorCodePspPerMerchat = "000000900000002";
                var seq = DateToTimeSpan(DateTime.Now);
                var terminalNumberPspPerMercha = "47725002";
                var iban = "IR890610000000400811282652";//IR110190000000326787748005//"IR500190000000323721603008"//"IR260190000000114808870000";//"IR880560085602002134463001";
                var iin = "581672121";
                var postalCode = "1516714414";
                var nationalCode = "0061100722";

                var result = new ShaparakRequest
                {
                    trackingNumberPsp = Guid.NewGuid().ToString(),
                    //Description = null,
                    relatedMerchants = null,
                    requestType = RequstTypeEnum.DefineMerchant,
                    merchant = new Merchant()
                    { //M mandetory
                        //O optional
                        //R haghighi
                        //H hoghoghi
                        firstNameFa = "علیرضا",//M R
                        lastNameFa = "رجبی",//M R
                        fatherNameFa = "صادق",//M R
                        firstNameEn = "alireza",//O
                        lastNameEn = "rajabi",//O
                        fatherNameEn = "sadegh",//O
                        gender = GenderEnum.Man,//M R
                        birthDate = birthDate,//M R
                        //registerDate = registerDate//M H 
                        nationalCode = nationalCode,//M R
                        comNameFa = "تمدن",//M H
                        comNameEn = "tamadonpay",//O
                        merchantType = MerchantTypeEnum.Haghighi,//M
                        residencyType = ResidencyTypeEnum.Irani,//M
                        vitalStatus = VitalStatusEnum.Yes,
                        //nationalLegalCode = "101010",//M H //شناسه ملی اشخاص حقوقی
                        // countryCode = "IR",//
                        // foreignPervasiveCode = "",//M R//code atba
                        passportNumber = null,//M R//code atba
                        passportExpireDate = null, //M R//code atba
                        telephoneNumber = "021-44589814", //M
                        cellPhoneNumber = "09363068269",//M
                        merchantIbans = new List<MerchantIban> { new MerchantIban { merchantIban = iban } },

                    },

                    contract = new Contract
                    {
                        contractDate = ContarctDate,
                        serviceStartDate = ContarctDate,

                        contractNumber = "101255",//M //shomareh 



                    },
                    //pspRequestShopAcceptors =new List<ShopAcceptor> { new ShopAcceptor { acceptors = } }
                    pspRequestShopAcceptors = new List<ShopAcceptor>()
                    {
                        new ShopAcceptor
                        {
                            acceptors = new List<Acceptor>
                        {
                            new Acceptor
                            {
                                iin = iin,//?
                                acceptorCode = acceptorCodePspPerMerchat,//az psp
                                acceptorType = AcceptorTypeEnum.All,
                                facilitatorAcceptorCode = "100000048825000",//code acceptor ma//000000900000001
                                shaparakSettlementIbans = new List<string>{ iban },
                                terminals =new List<Terminal>
                                {
                                    new Terminal
                                    {
                                        sequence = seq,//uniqe
                                        terminalNumber = terminalNumberPspPerMercha,
                                        terminalType = TerminalTypeEnum.Ipg,
                                        setupDate = datenow,
                                        accessAddress = "https://tamadonpay.com",
                                        accessPort = 80,
                                        callbackAddress = "https://tamadonpay.com",
                                        callbackPort = 80,

                                    }
                                },
                                allowAmericanExpressTrx = true,
                                allowFoodSecurityTrx = true,
                                allowGoodsBasketTrx = true,
                                allowIranianProductsTrx = true,
                                allowJcbCardTrx = true,
                                allowKaraCardTrx = true,
                                allowMasterCardTrx = true,
                                allowOtherInternationaCardsTrx = true,
                                allowVisaCardTrx = true,
                                blockable = true,
                                cancelable = true,
                                chargeBackable = true,
                                allowUpiCardTrx = true,
                                allowScatteredSettlement = AllowScatteredSettlementEnum.NoTaghsimVajh,
                            }
                        },
                            shop = new Shop
                        {

                            farsiName = "فروشگاه تستی",
                            englishName = "test shop",
                            telephoneNumber = "021-44589814",
                            postalCode = postalCode,
                            businessCategoryCode = "5816",
                            businessSubCategoryCode = "0",
                            countryCode = "IR",// just Ir
                            businessType = BusinessTypeEnum.FisikiMajazi,
                            websiteAddress = "https://tamadonpay.com",
                            emailAddress = "tamadonpay@gmail.com",
                            taxPayerCode = "1234567898",
                        }
                        }
                    }
                };
                var listResult = new List<ShaparakRequest>
                {
                    result
                };
                return listResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public List<ShaparakRequest> FillAllData3()
        {
            try
            {
                var birthDate = PersionDateToTimeSpan("1363/12/07");
                var registerDate = PersionDateToTimeSpan("1400/01/30");//tarigh sabt hoghoghi
                var ContarctDate = DateToTimeSpan(DateTime.Now);//tarigh sabt hoghoghi
                var datenow = DateToTimeSpan(DateTime.Now);
                var acceptorCodePspPerMerchat = "000000900000003";
                var seq = DateToTimeSpan(DateTime.Now);
                var terminalNumberPspPerMercha = "47725003";
                var iban = "IR260190000000114808870000";//IR110190000000326787748005//"IR500190000000323721603008"//"IR260190000000114808870000";//"IR880560085602002134463001";
                var iin = "581672121";
                var postalCode = "1516714414";
                var nationalCode = "0061100722";

                var result = new ShaparakRequest
                {
                    trackingNumberPsp = Guid.NewGuid().ToString(),
                    //Description = null,
                    relatedMerchants = null,
                    requestType = RequstTypeEnum.DefineMerchant,
                    merchant = new Merchant()
                    {
                        firstNameFa = "علیرضا",//M R
                        lastNameFa = "رجبی",//M R
                        fatherNameFa = "صادق",//M R
                        firstNameEn = "alireza",//O
                        lastNameEn = "rajabi",//O
                        fatherNameEn = "sadegh",//O
                        gender = GenderEnum.Man,//M R
                        birthDate = birthDate,//M R
                        //registerDate = registerDate//M H 
                        nationalCode = nationalCode,//M R
                        comNameFa = "تمدن",//M H
                        comNameEn = "tamadonpay",//O
                        merchantType = MerchantTypeEnum.Haghighi,//M
                        residencyType = ResidencyTypeEnum.Irani,//M
                        vitalStatus = VitalStatusEnum.Yes,
                        //nationalLegalCode = "101010",//M H //شناسه ملی اشخاص حقوقی
                        // countryCode = "IR",//
                        // foreignPervasiveCode = "",//M R//code atba
                        passportNumber = null,//M R//code atba
                        passportExpireDate = null, //M R//code atba
                        telephoneNumber = "021-44589814", //M
                        cellPhoneNumber = "09363068269",//M
                        merchantIbans = new List<MerchantIban> { new MerchantIban { merchantIban = iban } },

                    },

                    contract = new Contract
                    {
                        contractDate = ContarctDate,
                        serviceStartDate = ContarctDate,

                        contractNumber = "101255",//M //shomareh 



                    },
                    //pspRequestShopAcceptors =new List<ShopAcceptor> { new ShopAcceptor { acceptors = } }
                    pspRequestShopAcceptors = new List<ShopAcceptor>()
                    {
                        new ShopAcceptor
                        {
                            acceptors = new List<Acceptor>
                        {
                            new Acceptor
                            {
                                iin = iin,//?
                                acceptorCode = acceptorCodePspPerMerchat,//az psp
                                acceptorType = AcceptorTypeEnum.All,
                                facilitatorAcceptorCode = "100000048825000",//code acceptor ma//000000900000001
                                shaparakSettlementIbans = new List<string>{ iban },
                                terminals =new List<Terminal>
                                {
                                    new Terminal
                                    {
                                        sequence = seq,//uniqe
                                        terminalNumber = terminalNumberPspPerMercha,
                                        terminalType = TerminalTypeEnum.Ipg,
                                        setupDate = datenow,
                                        accessAddress = "https://tamadonpay.com",
                                        accessPort = 80,
                                        callbackAddress = "https://tamadonpay.com",
                                        callbackPort = 80,

                                    }
                                },
                                allowAmericanExpressTrx = true,
                                allowFoodSecurityTrx = true,
                                allowGoodsBasketTrx = true,
                                allowIranianProductsTrx = true,
                                allowJcbCardTrx = true,
                                allowKaraCardTrx = true,
                                allowMasterCardTrx = true,
                                allowOtherInternationaCardsTrx = true,
                                allowVisaCardTrx = true,
                                blockable = true,
                                cancelable = true,
                                chargeBackable = true,
                                allowUpiCardTrx = true,
                                allowScatteredSettlement = AllowScatteredSettlementEnum.NoTaghsimVajh,
                            }
                        },
                            shop = new Shop
                        {
                            farsiName = "فروشگاه تستی3",
                            englishName = "test shop",
                            telephoneNumber = "021-44589814",
                            postalCode = postalCode,
                            businessCategoryCode = "5812",
                            businessSubCategoryCode = "0",
                            countryCode = "IR",// just Ir
                            businessType = BusinessTypeEnum.FisikiMajazi,
                            websiteAddress = "https://tamadonpay.com",
                            emailAddress = "tamadonpay@gmail.com",
                            taxPayerCode = "1234567888",
                        }
                        }
                    }
                };
                var listResult = new List<ShaparakRequest>
                {
                    result
                };
                return listResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public List<ShaparakRequest> FillAllData4()
        {
            try
            {
                var birthDate = PersionDateToTimeSpan("1360/10/20");
                var registerDate = PersionDateToTimeSpan("1399/01/30");//tarigh sabt hoghoghi
                var ContarctDate = DateToTimeSpan(DateTime.Now);//tarigh sabt hoghoghi
                var datenow = DateToTimeSpan(DateTime.Now);
                var acceptorCodePspPerMerchat = "000000900000004";
                var seq = DateToTimeSpan(DateTime.Now);
                var terminalNumberPspPerMercha = "47725004";
                var iban = "IR260560080280000203021001";//IR110190000000326787748005//"IR500190000000323721603008"//"IR260190000000114808870000";//"IR880560085602002134463001";
                var iin = "581672121";
                var postalCode = "1516714414";
                var nationalCode = "1260501655";
                var result = new ShaparakRequest
                {
                    trackingNumberPsp = Guid.NewGuid().ToString(),
                    //Description = null,
                    relatedMerchants = null,
                    requestType = RequstTypeEnum.DefineMerchant,
                    merchant = new Merchant()
                    {
                        //M mandetory
                        //O optional
                        //R haghighi
                        //H hoghoghi
                        firstNameFa = "مهدی",//M R
                        lastNameFa = "معرفتی",//M R
                        fatherNameFa = "صادق",//M R
                        firstNameEn = "mehdi",//O
                        lastNameEn = "marefati",//O
                        fatherNameEn = "sadegh",//O
                        gender = GenderEnum.Man,//M R
                        birthDate = birthDate,//M R
                        //registerDate = registerDate//M H 
                        nationalCode = nationalCode,//M R
                        comNameFa = "تمدن",//M H
                        comNameEn = "tamadonpay",//O
                        merchantType = MerchantTypeEnum.Haghighi,//M
                        residencyType = ResidencyTypeEnum.Irani,//M
                        vitalStatus = VitalStatusEnum.Yes,
                        //nationalLegalCode = "101010",//M H //شناسه ملی اشخاص حقوقی
                        // countryCode = "IR",//
                        // foreignPervasiveCode = "",//M R//code atba
                        passportNumber = null,//M R//code atba
                        passportExpireDate = null, //M R//code atba
                        telephoneNumber = "021-44589814", //M
                        cellPhoneNumber = "09363068269",//M
                        merchantIbans = new List<MerchantIban> { new MerchantIban { merchantIban = iban } },

                    },

                    contract = new Contract
                    {
                        contractDate = ContarctDate,
                        serviceStartDate = ContarctDate,

                        contractNumber = "101255",//M //shomareh 



                    },
                    //pspRequestShopAcceptors =new List<ShopAcceptor> { new ShopAcceptor { acceptors = } }
                    pspRequestShopAcceptors = new List<ShopAcceptor>()
                    {
                        new ShopAcceptor
                        {
                            acceptors = new List<Acceptor>
                        {
                            new Acceptor
                            {
                                iin = iin,//?
                                acceptorCode = acceptorCodePspPerMerchat,//az psp
                                acceptorType = AcceptorTypeEnum.All,
                                facilitatorAcceptorCode = "100000048825000",//code acceptor ma//000000900000001
                                shaparakSettlementIbans = new List<string>{ iban },
                                terminals =new List<Terminal>
                                {
                                    new Terminal
                                    {
                                        sequence = seq,//uniqe
                                        terminalNumber = terminalNumberPspPerMercha,
                                        terminalType = TerminalTypeEnum.Ipg,
                                        setupDate = datenow,
                                        accessAddress = "https://tamadonpay.com",
                                        accessPort = 80,
                                        callbackAddress = "https://tamadonpay.com",
                                        callbackPort = 80,

                                    }
                                },
                                allowAmericanExpressTrx = true,
                                allowFoodSecurityTrx = true,
                                allowGoodsBasketTrx = true,
                                allowIranianProductsTrx = true,
                                allowJcbCardTrx = true,
                                allowKaraCardTrx = true,
                                allowMasterCardTrx = true,
                                allowOtherInternationaCardsTrx = true,
                                allowVisaCardTrx = true,
                                blockable = true,
                                cancelable = true,
                                chargeBackable = true,
                                allowUpiCardTrx = true,
                                allowScatteredSettlement = AllowScatteredSettlementEnum.NoTaghsimVajh,
                            }
                        },
                            shop = new Shop
                        {
                                taxPayerCode = "1234567777",
                            farsiName = "فروشگاه تستی4",
                            englishName = "test shop",
                            telephoneNumber = "021-44589814",
                            postalCode = postalCode,
                            businessCategoryCode = "5812",
                            businessSubCategoryCode = "0",
                            countryCode = "IR",// just Ir
                            businessType = BusinessTypeEnum.FisikiMajazi,
                            websiteAddress = "https://tamadonpay.com",
                            emailAddress = "tamadonpay@gmail.com",
                        }
                        }
                    }
                };
                var listResult = new List<ShaparakRequest>
                {
                    result
                };
                return listResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }


        internal ShaparakFileSettelment FillFileSettelmentOk()
        {
            var iin = 581672121;
            var paymentFacilitatorIban = "IR590570037370014135468101";//sheba ma
           
            var result = new ShaparakFileSettelment
            {
                settlementDataDetails = new List<settlementDataDetails>
                {
                    new settlementDataDetails
                    {
                    iin = iin,
                    acceptorCode = "000000900000001",
                    paymentFacilitatorIban = paymentFacilitatorIban,
                    settlementAmount = 8844139,
                    settlementIban = "IR880560085602002134463001",
                    wageAmount = 0
                    },
                    new settlementDataDetails
                    {
                    iin = iin,
                    acceptorCode = "000000900000002",
                    paymentFacilitatorIban = paymentFacilitatorIban,
                    settlementAmount = 381000,
                    settlementIban = "IR890610000000400811282652",
                    wageAmount = 0
                    },
                    new settlementDataDetails
                    {
                    iin = iin,
                    acceptorCode = "000000900000003",
                    paymentFacilitatorIban = paymentFacilitatorIban,
                    settlementAmount = 1802843,
                    settlementIban = "IR260190000000114808870000",
                    wageAmount = 90143
                    },
                    new settlementDataDetails
                    {
                    iin = iin,
                    acceptorCode = "000000900000004",
                    paymentFacilitatorIban = paymentFacilitatorIban,
                    settlementAmount = 839714,
                    settlementIban = "IR260560080280000203021001",
                    wageAmount = 41986
                    },
                }

            };

            return result;

        }
        internal ShaparakFileSettelment FillFileSettelmentNotOk1()
        {
            var iin = 581672121;
            var paymentFacilitatorIban = "IR590570037370014135468101";//sheba ma

            var result = new ShaparakFileSettelment
            {
                settlementDataDetails = new List<settlementDataDetails>
                {
                    new settlementDataDetails
                    {
                    iin = iin,
                    acceptorCode = "000000900000001",
                    paymentFacilitatorIban = paymentFacilitatorIban,
                    settlementAmount = 8844200,
                    settlementIban = "IR880560085602002134463001",
                    wageAmount = 0
                    },
                    new settlementDataDetails
                    {
                    iin = iin,
                    acceptorCode = "000000900000002",
                    paymentFacilitatorIban = paymentFacilitatorIban,
                    settlementAmount = 382000,
                    settlementIban = "IR890610000000400811282652",
                    wageAmount = 19087
                    },
                    new settlementDataDetails
                    {
                    iin = iin,
                    acceptorCode = "000000900000003",
                    paymentFacilitatorIban = paymentFacilitatorIban,
                    settlementAmount = 1000000,
                    settlementIban = "IR260190000000114808870000",
                    wageAmount = 361000
                    },
                    new settlementDataDetails
                    {
                    iin = iin,
                    acceptorCode = "000000900000003",
                    paymentFacilitatorIban = paymentFacilitatorIban,
                    settlementAmount = 500000,
                    settlementIban = "IR260560080280000203021001",
                    wageAmount = 0
                    },
                }

            };

            return result;

        }
        internal ShaparakFileSettelment FillFileSettelmentNotOk2()
        {
            var iin = 581672121;
            var paymentFacilitatorIban = "IR590570037370014135468101";//sheba ma

            var result = new ShaparakFileSettelment
            {
                settlementDataDetails = new List<settlementDataDetails>
                {
                    new settlementDataDetails
                    {
                    iin = 581672122,
                    acceptorCode = "000000900000001",
                    paymentFacilitatorIban = paymentFacilitatorIban,
                    settlementAmount = 8844139,
                    settlementIban = "IR880560085602002134463001",
                    wageAmount = 0
                    },
                    new settlementDataDetails
                    {
                    iin = iin,
                    acceptorCode = "000000900000055",
                    paymentFacilitatorIban = paymentFacilitatorIban,
                    settlementAmount = 381000,
                    settlementIban = "IR890610000000400811282652",
                    wageAmount = 0
                    },
                    new settlementDataDetails
                    {
                    iin = iin,
                    acceptorCode = "000000900000003",
                    paymentFacilitatorIban = "IR110190000000326787748005",
                    settlementAmount = 1802843,
                    settlementIban = "IR260190000000114808870000",
                    wageAmount = 0
                    },
                    new settlementDataDetails
                    {
                    iin = iin,
                    acceptorCode = "000000900000004",
                    paymentFacilitatorIban = paymentFacilitatorIban,
                    settlementAmount = 839714,
                    settlementIban = "IR260560080280000203021004",
                    wageAmount = 0
                    },
                }

            };

            return result;

        }
        internal ShaparakFileSettelment FillFileSettelmentTrue()
        {
            var iin = 581672121;
            var paymentFacilitatorIban = "IR590570037370014135468101";//sheba ma

            var result = new ShaparakFileSettelment
            {
                settlementDataDetails = new List<settlementDataDetails>
                {
                    new settlementDataDetails
                    {
                    iin = iin,
                    acceptorCode = "000000900000001",
                    paymentFacilitatorIban = paymentFacilitatorIban,
                    settlementAmount = 6765151,
                    settlementIban = "IR880560085602002134463001",
                    wageAmount = 30000
                    },
                    new settlementDataDetails
                    {
                    iin = iin,
                    acceptorCode = "000000900000002",
                    paymentFacilitatorIban = paymentFacilitatorIban,
                    settlementAmount = 3886146,
                    settlementIban = "IR890610000000400811282652",
                    wageAmount = 30000
                    },
                    new settlementDataDetails
                    {
                    iin = iin,
                    acceptorCode = "000000900000003",
                    paymentFacilitatorIban = paymentFacilitatorIban,
                    settlementAmount = 3186372,
                    settlementIban = "IR260190000000114808870000",
                    wageAmount = 30000
                    },
                    new settlementDataDetails
                    {
                    iin = iin,
                    acceptorCode = "000000900000004",
                    paymentFacilitatorIban = paymentFacilitatorIban,
                    settlementAmount = 5349913,
                    settlementIban = "IR260560080280000203021001",
                    wageAmount = 30000
                    },
                }

            };

            return result;

        }

        public long PersionDateToTimeSpan(string personDate)
        {

            var dt = PersianDateHelper.Instance.ConvertToMiladiDate(personDate);
            //var dt = DateTime.Parse("2020/11/20");
            long unixTime = ((DateTimeOffset)dt).ToUnixTimeMilliseconds();
            return unixTime;
        }
        public long DateToTimeSpan(DateTime date)
        {
            long unixTime = ((DateTimeOffset)date).ToUnixTimeMilliseconds();
            return unixTime;
        }
    }
}
