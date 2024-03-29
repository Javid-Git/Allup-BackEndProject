#pragma checksum "C:\Users\user\source\repos\AllUp\Views\Shared\_AddToCartPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "758b16ce64b55e4cbd7fbc0d99de076b063b6a8d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__AddToCartPartial), @"mvc.1.0.view", @"/Views/Shared/_AddToCartPartial.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 2 "C:\Users\user\source\repos\AllUp\Views\_ViewImports.cshtml"
using AllUp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\user\source\repos\AllUp\Views\_ViewImports.cshtml"
using AllUp.ViewModels.BasketViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\user\source\repos\AllUp\Views\_ViewImports.cshtml"
using AllUp.ViewModels.HeaderViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\user\source\repos\AllUp\Views\_ViewImports.cshtml"
using AllUp.ViewModels.HomeViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\user\source\repos\AllUp\Views\_ViewImports.cshtml"
using AllUp.ViewModels.AccountViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"758b16ce64b55e4cbd7fbc0d99de076b063b6a8d", @"/Views/Shared/_AddToCartPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91c3fc4e9570a4fd905b8a0314e8031e78bca285", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__AddToCartPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<BasketVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("product"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "basket", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteFromBasket", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("product-close deletefrombasket"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<div class=\"cart-btn\">\r\n    <a href=\"#\">\r\n        <i class=\"icon ion-bag\"></i>\r\n        <span class=\"text\">Cart :</span>\r\n        <span class=\"total\">$");
#nullable restore
#line 8 "C:\Users\user\source\repos\AllUp\Views\Shared\_AddToCartPartial.cshtml"
                        Write(Model.Sum(b => b.Price * b.SelectCount + b.ExTax * b.SelectCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        <span class=\"count\">");
#nullable restore
#line 9 "C:\Users\user\source\repos\AllUp\Views\Shared\_AddToCartPartial.cshtml"
                       Write(Model.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n    </a>\r\n</div>\r\n<div class=\"mini-cart\">\r\n    <ul class=\"cart-items\">\r\n");
#nullable restore
#line 14 "C:\Users\user\source\repos\AllUp\Views\Shared\_AddToCartPartial.cshtml"
         foreach (BasketVM BasketVM in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li>\r\n                <div class=\"single-cart-item d-flex\">\r\n                    <div class=\"cart-item-thumb\">\r\n                        <a href=\"single-product.html\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "758b16ce64b55e4cbd7fbc0d99de076b063b6a8d6370", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 620, "~/assets/images/product/", 620, 24, true);
#nullable restore
#line 19 "C:\Users\user\source\repos\AllUp\Views\Shared\_AddToCartPartial.cshtml"
AddHtmlAttributeValue("", 644, BasketVM.Image, 644, 15, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</a>\r\n                        <span class=\"product-quantity\">");
#nullable restore
#line 20 "C:\Users\user\source\repos\AllUp\Views\Shared\_AddToCartPartial.cshtml"
                                                   Write(BasketVM.SelectCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("x</span>\r\n                    </div>\r\n                    <div class=\"cart-item-content media-body\">\r\n                        <h5 class=\"product-name\"><a href=\"single-product.html\">");
#nullable restore
#line 23 "C:\Users\user\source\repos\AllUp\Views\Shared\_AddToCartPartial.cshtml"
                                                                          Write(BasketVM.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h5>\r\n                        <span class=\"product-price\">€");
#nullable restore
#line 24 "C:\Users\user\source\repos\AllUp\Views\Shared\_AddToCartPartial.cshtml"
                                                 Write(BasketVM.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        <span class=\"product-color\"><strong>Color:</strong> White</span>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "758b16ce64b55e4cbd7fbc0d99de076b063b6a8d9191", async() => {
                WriteLiteral("<i class=\"fal fa-times\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 26 "C:\Users\user\source\repos\AllUp\Views\Shared\_AddToCartPartial.cshtml"
                                                                                   WriteLiteral(BasketVM.ProdId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </li>\r\n");
#nullable restore
#line 30 "C:\Users\user\source\repos\AllUp\Views\Shared\_AddToCartPartial.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\r\n    <div class=\"price_content\">\r\n        <div class=\"cart-subtotals\">\r\n            <div class=\"products price_inline\">\r\n                <span class=\"label\">Subtotal</span>\r\n                <span class=\"value\">€");
#nullable restore
#line 36 "C:\Users\user\source\repos\AllUp\Views\Shared\_AddToCartPartial.cshtml"
                                Write(Model.Sum(b => b.Price * b.SelectCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </div>\r\n            <div class=\"tax price_inline\">\r\n                <span class=\"label\">Taxes</span>\r\n                <span class=\"value\">€");
#nullable restore
#line 40 "C:\Users\user\source\repos\AllUp\Views\Shared\_AddToCartPartial.cshtml"
                                Write(Model.Sum(b => b.ExTax * b.SelectCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </div>\r\n        </div>\r\n        <div class=\"cart-total price_inline\">\r\n            <span class=\"label\">Total</span>\r\n            <span class=\"value\">€");
#nullable restore
#line 45 "C:\Users\user\source\repos\AllUp\Views\Shared\_AddToCartPartial.cshtml"
                             Write(Model.Sum(b => b.Price * b.SelectCount) + Model.Sum(b => b.ExTax * b.SelectCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        </div>\r\n    </div> <!-- price content -->\r\n    <div class=\"checkout text-center\">\r\n        <a href=\"checkout.html\" class=\"main-btn\">Checkout</a>\r\n    </div>\r\n\r\n</div> <!-- mini cart -->");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<BasketVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
