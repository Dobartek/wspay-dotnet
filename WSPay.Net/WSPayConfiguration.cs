namespace WSPay.Net
{
    using System.Configuration;
    using System;
    
    public static class WSPayConfiguration
    {
        private static Mode mode { get; set; } = Mode.Test;
        private static Shop tokenShop { get; set; }
        private static Shop regularShop { get; set; }
        
        public static Mode Mode
        {
            get
            {
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["WSPayMode"]))
                {
                    if (!Enum.TryParse<Mode>(ConfigurationManager.AppSettings["WSPayMode"], out var parsedMode))
                    {
                        throw new ArgumentException("Invalid WSPayMode configured");
                    }

                    mode = parsedMode;
                }

                return mode;
            }

            set => mode = value;
        }
        
        public static Shop TokenShop
        {
            get
            {
                if (tokenShop == null 
                    && !string.IsNullOrEmpty(ConfigurationManager.AppSettings["WSPayTokenShopId"])
                    && !string.IsNullOrEmpty(ConfigurationManager.AppSettings["WSPayTokenShopSecret"]))
                {
                    tokenShop = new Shop(ConfigurationManager.AppSettings["WSPayTokenShopId"], ConfigurationManager.AppSettings["WSPayTokenShopSecret"]);
                }

                return tokenShop;
            }

            set => tokenShop = value;
        }
        
        public static Shop RegularShop
        {
            get
            {
                if (regularShop == null)
                {
                    if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["WSPayRegularShopId"]) || string.IsNullOrEmpty(ConfigurationManager.AppSettings["WSPayRegularShopSecret"]))
                    {
                        var message = "Invalid configuration. WSPay Regular shop must be configured. WSPayRegularShopId or WSPayRegularShopSecret missing";
                        throw new WSPayException(message);
                    }
                    
                    regularShop = new Shop(ConfigurationManager.AppSettings["WSPayRegularShopId"], ConfigurationManager.AppSettings["WSPayRegularShopSecret"]);
                }

                return regularShop;
            }

            set => regularShop = value;
        }
        
        public static Uri BaseApiUrl
        {
            get
            {
                switch (Mode)
                {
                    case Mode.Prod:
                        return new Uri("https://secure.wspay.biz");
                    case Mode.Test:
                        return new Uri("https://test.wspay.biz");
                
                    default:
                        throw new ArgumentException("Invalid mode");
                }
            }
        }
        
        public static Uri FormUrl
        {
            get
            {
                switch (Mode)
                {
                    case Mode.Prod:
                        return new Uri("https://form.wspay.biz/Authorization.aspx");
                    case Mode.Test:
                        return new Uri("https://formtest.wspay.biz/Authorization.aspx");
                
                    default:
                        throw new ArgumentException("Invalid mode");
                }
            }
        }
    }
}