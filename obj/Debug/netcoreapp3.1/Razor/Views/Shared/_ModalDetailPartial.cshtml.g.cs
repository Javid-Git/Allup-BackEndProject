#pragma checksum "C:\Users\user\source\repos\AllUp\Views\Shared\_ModalDetailPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "57afe3a698bfec28d5a0f5ea2c57feaaf7909976"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ModalDetailPartial), @"mvc.1.0.view", @"/Views/Shared/_ModalDetailPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57afe3a698bfec28d5a0f5ea2c57feaaf7909976", @"/Views/Shared/_ModalDetailPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe5d8b01f71728ac700fecfd9b2342a6e635cbd5", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ModalDetailPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Product>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("product"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "3", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "4", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<div class=""modal-header"">
    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
        <i class=""fal fa-times""></i>
    </button>
</div>
<div class=""modal-body"">
    <div class=""row"">
        <div class=""col-md-6"">
            <div class=""product-quick-view-image mt-30"">
                <div class=""quick-view-image"">
");
#nullable restore
#line 14 "C:\Users\user\source\repos\AllUp\Views\Shared\_ModalDetailPartial.cshtml"
                     foreach (Photo photo in Model.Photos)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"single-view-image\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "57afe3a698bfec28d5a0f5ea2c57feaaf79099766198", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 556, "~/assets/images/product-quick/", 556, 30, true);
#nullable restore
#line 17 "C:\Users\user\source\repos\AllUp\Views\Shared\_ModalDetailPartial.cshtml"
AddHtmlAttributeValue("", 586, photo.Image, 586, 12, false);

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
            WriteLiteral("\r\n                        </div>\r\n");
#nullable restore
#line 19 "C:\Users\user\source\repos\AllUp\Views\Shared\_ModalDetailPartial.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n                <ul class=\"quick-view-thumb\">\r\n");
#nullable restore
#line 22 "C:\Users\user\source\repos\AllUp\Views\Shared\_ModalDetailPartial.cshtml"
                     foreach (Photo photo in Model.Photos)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li>\r\n                            <div class=\"single-thumb\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "57afe3a698bfec28d5a0f5ea2c57feaaf79099768484", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 953, "~/assets/images/product-quick/", 953, 30, true);
#nullable restore
#line 26 "C:\Users\user\source\repos\AllUp\Views\Shared\_ModalDetailPartial.cshtml"
AddHtmlAttributeValue("", 983, photo.Image, 983, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </li>\r\n");
#nullable restore
#line 29 "C:\Users\user\source\repos\AllUp\Views\Shared\_ModalDetailPartial.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </ul>
            </div> <!-- Modal Quick View Image -->
        </div>
        <div class=""col-md-6"">
            <div class=""product-quick-view-content mt-30"">
                <h3 class=""product-title"">Trans-Weight Hooded Wind and Water Resistant Shell</h3>
                <p class=""reference"">Reference: demo_12</p>
                <ul class=""rating"">
                    <li class=""rating-on""><i class=""fas fa-star""></i></li>
                    <li class=""rating-on""><i class=""fas fa-star""></i></li>
                    <li class=""rating-on""><i class=""fas fa-star""></i></li>
                    <li class=""rating-on""><i class=""fas fa-star""></i></li>
                    <li class=""rating-on""><i class=""fas fa-star""></i></li>
                </ul>
                <div class=""product-prices"">
");
#nullable restore
#line 45 "C:\Users\user\source\repos\AllUp\Views\Shared\_ModalDetailPartial.cshtml"
                     if (Model.DicountedPrice > 0)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"regular-price\">€");
#nullable restore
#line 47 "C:\Users\user\source\repos\AllUp\Views\Shared\_ModalDetailPartial.cshtml"
                                                Write(Model.DicountedPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        <span class=\"sale-price\">€");
#nullable restore
#line 48 "C:\Users\user\source\repos\AllUp\Views\Shared\_ModalDetailPartial.cshtml"
                                             Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 49 "C:\Users\user\source\repos\AllUp\Views\Shared\_ModalDetailPartial.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"regular-price\">€");
#nullable restore
#line 52 "C:\Users\user\source\repos\AllUp\Views\Shared\_ModalDetailPartial.cshtml"
                                                Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 53 "C:\Users\user\source\repos\AllUp\Views\Shared\_ModalDetailPartial.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    <span class=""save"">Save 12%</span>
                </div>
                <p class=""product-description"">Block out the haters with the fresh adidas® Originals Kaval Windbreaker Jacket. <br> Part of the Kaval Collection. <br> Regular fit is eased, but not sloppy, and perfect for any activity. <br> Plain-woven jacket specifically constructed for freedom of movement.</p>
                <div class=""product-size-color flex-wrap"">
                    <div class=""product-size"">
                        <h5 class=""title"">Size</h5>
                        <select>
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "57afe3a698bfec28d5a0f5ea2c57feaaf790997613518", async() => {
                WriteLiteral("S");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "57afe3a698bfec28d5a0f5ea2c57feaaf790997614701", async() => {
                WriteLiteral("M");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "57afe3a698bfec28d5a0f5ea2c57feaaf790997615884", async() => {
                WriteLiteral("L");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "57afe3a698bfec28d5a0f5ea2c57feaaf790997617067", async() => {
                WriteLiteral("XL");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </select>
                    </div>
                    <div class=""product-color"">
                        <h5 class=""title"">Color</h5>
                        <div class=""color-input"">
                            <div class=""single-color color-1"">
                                <input type=""radio"" id=""radio-1"" name=""color"">
                                <label for=""radio-1""></label>
                            </div>
                            <div class=""single-color color-2"">
                                <input type=""radio"" id=""radio-2"" name=""color"">
                                <label for=""radio-2""></label>
                            </div>
                            <div class=""single-color color-3"">
                                <input type=""radio"" id=""radio-3"" name=""color"">
                                <label for=""radio-3""></label>
                            </div>
                        </div>
                    </div>
                ");
            WriteLiteral(@"    <div class=""product-quantity"">
                        <h5 class=""title"">Quantity</h5>
                        <div class=""quantity d-flex"">
                            <button type=""button"" id=""sub"" class=""sub""><i class=""fal fa-minus""></i></button>
                            <input type=""text"" value=""1"" />
                            <button type=""button"" id=""add"" class=""add""><i class=""fal fa-plus""></i></button>
                        </div>
                    </div>
                </div>
                <div class=""product-add-cart"">
                    <button><i class=""icon ion-bag""></i> Add to cart</button>
                </div>
                <div class=""product-wishlist-compare"">
                    <ul class=""d-flex flex-wrap"">
                        <li><a href=""#""><i class=""fal fa-heart""></i> Add to wishlist</a></li>
                        <li><a href=""#""><i class=""fal fa-repeat""></i> Add to compare</a></li>
                    </ul>
                </div>
             ");
            WriteLiteral(@"   <div class=""product-share d-flex"">
                    <p>Share</p>
                    <ul class=""social media-body"">
                        <li><a href=""#""><i class=""fab fa-facebook-f""></i></a></li>
                        <li><a href=""#""><i class=""fab fa-twitter""></i></a></li>
                        <li><a href=""#""><i class=""fab fa-google""></i></a></li>
                        <li><a href=""#""><i class=""fab fa-pinterest-p""></i></a></li>
                    </ul>
                </div>
            </div> <!-- Modal Quick View Content -->
        </div>
    </div> <!-- row -->
</div>  <!-- Modal Body -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Product> Html { get; private set; }
    }
}
#pragma warning restore 1591
