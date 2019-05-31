using Arcteryx.Utils;
using OpenQA.Selenium;
using System;

namespace Arcteryx.Pages
{
    /// <summary>
    /// Describe element on the product page.
    /// </summary>
    public class ItemPage : PageBase
    {
        /// <summary>
        /// Locators for web elements.
        /// </summary>
        #region
        protected const String ITEM_NAME = "//h1[@data-marketing-name-en]";
        protected const String ADD_TO_CART_BUTTON = "//input [@id='add-to-cart-button']";
        protected const String SELECT_COLOUR = "//div[@data-name and contains(@class, 'product-colour__thumbnail-container')]";
        protected const String EMPTY_CLICK = "//div[@class='product__above-the-fold']";
        protected const String CHECKOUT_BUTTON = "//a [contains(text(), 'Secure Checkout')]";
        #endregion

        public ItemPage(AppManager appManager) : base(appManager)
        {
        }

        /// <summary>
        /// Size availability check.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool CheckStock(IWebElement element)
        {
            String value;
            value = element.GetAttribute("data-stock");

            if ((value == "Sold Out") || (value == "Sold Out")) 
                {
                return false;
            }
            else
               {
                return true;
            }         
        }

        /// <summary>
        /// Select item color.
        /// </summary>
        /// <param name="colors"></param>
        /// <returns></returns>
        public ItemPage SelectColor(Enum colors)
        {
            String locator;
            String color;

            switch(colors)
            {
                case Enums.Colors.RedBeach:
                    color = "Red Beach";  
                    break;
                case Enums.Colors.HoweSound:
                    color = "Red Beach";
                    break;
                case Enums.Colors.Black:
                    color = "Black";
                    break;
                case Enums.Colors.Pilot:
                    color = "Pilot";
                    break;

                default:
                    color = "Red Beach";
                    throw new Exception("Incorrect color");
            }

            locator = $"//div[@data-name='{color}']";
            FindByXpath(locator).Click();

            return this;
        }

        /// <summary>
        /// Select size.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public ItemPage SelectSize(String size)
        {
            String locator;
            IWebElement sizeButton;
          
            switch (size)
            {
                case "XS":
                    locator = $"//div[@data-primary-size = '{Enums.SizeEnum.XS}']";
                    break;
                case "S":
                    locator = $"//div[@data-primary-size = '{Enums.SizeEnum.S}']";
                    break;
                case "M":
                    locator = $"//div[@data-primary-size = '{Enums.SizeEnum.M}']";
                    break;
                case "L":
                    locator = $"//div[@data-primary-size = '{Enums.SizeEnum.L}']";
                    break;
                case "XL":
                    locator = $"//div[@data-primary-size = '{Enums.SizeEnum.XL}']";
                    break;
                case "XXL":
                    locator = $"//div[@data-primary-size = '{Enums.SizeEnum.XXL}']";
                    break;
                default:
                    locator = $"//div[@data-primary-size = '{Enums.SizeEnum.XS}']";
                    break;
            }

            sizeButton = FindByXpath(locator);

            if (CheckStock(sizeButton))
            {
                sizeButton.Click();
            }
            else
            {
                throw new Exception("Size out of stock!");
            }

            return this;
        }

        /// <summary>
        /// Click on "Add to cart" button.
        /// </summary>
        /// <returns></returns>
        public ItemPage AddToCartClick()
        {
            FindByXpath(ADD_TO_CART_BUTTON).Click();
            return this;
        }

        /// <summary>
        /// Close small cart window, witch appear after adding to cart.
        /// </summary>
        /// <returns></returns>
        public ItemPage CloseCartWindow()
        {
            FindByXpath(CHECKOUT_BUTTON);
            FindByXpath(EMPTY_CLICK).Click();
            return this;
        }
    }
}
