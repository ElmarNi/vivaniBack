#pragma checksum "C:\Users\User\Desktop\Vivani Back\Vivani Back\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d81fadc52867308234b12d4f37ceb9d2fbb07b9e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Users\User\Desktop\Vivani Back\Vivani Back\Views\_ViewImports.cshtml"
using VivaniBack;

#line default
#line hidden
#line 2 "C:\Users\User\Desktop\Vivani Back\Vivani Back\Views\_ViewImports.cshtml"
using VivaniBack.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d81fadc52867308234b12d4f37ceb9d2fbb07b9e", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"359db6935a9e4d663ddeea509311af997d31f77a", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HomeVm>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(14, 162, true);
            WriteLiteral("<section id=\"slider\">\n    <div class=\"container-fluid\">\n        <div class=\"row\">\n            <div class=\"col-12 p-0\">\n                <div class=\"owl-carousel\">\n");
            EndContext();
#line 7 "C:\Users\User\Desktop\Vivani Back\Vivani Back\Views\Home\Index.cshtml"
                     foreach (var item in Model.homeSliders)
                    {

#line default
#line hidden
            BeginContext(259, 48, true);
            WriteLiteral("                        <div class=\"custom-item\"");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 307, "\"", 363, 4);
            WriteAttributeValue("", 315, "background-image:", 315, 17, true);
            WriteAttributeValue(" ", 332, "url(../../img/", 333, 15, true);
#line 9 "C:\Users\User\Desktop\Vivani Back\Vivani Back\Views\Home\Index.cshtml"
WriteAttributeValue("", 347, item.ImageUrl, 347, 14, false);

#line default
#line hidden
            WriteAttributeValue("", 361, ");", 361, 2, true);
            EndWriteAttribute();
            BeginContext(364, 87, true);
            WriteLiteral(">\n                            <div class=\"content\">\n                                <p>");
            EndContext();
            BeginContext(452, 17, false);
#line 11 "C:\Users\User\Desktop\Vivani Back\Vivani Back\Views\Home\Index.cshtml"
                              Write(item.LittleHeader);

#line default
#line hidden
            EndContext();
            BeginContext(469, 291, true);
            WriteLiteral(@"</p>
                                <h1>Classic jewellery collection</h1>
                                <a href="""" class=""sliderB mainBtn"">
                                    Shop Now
                                </a>
                            </div>
                        </div>
");
            EndContext();
#line 18 "C:\Users\User\Desktop\Vivani Back\Vivani Back\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
            BeginContext(782, 160, true);
            WriteLiteral("                </div>\n            </div>\n        </div>\n    </div>\n</section>\n<section id=\"whyChooseUs\">\n    <div class=\"container\">\n        <div class=\"row\">\n");
            EndContext();
#line 27 "C:\Users\User\Desktop\Vivani Back\Vivani Back\Views\Home\Index.cshtml"
             for (int i = 0; i < Model.whyChooseUs.Count(); i++)
            {

#line default
#line hidden
            BeginContext(1021, 20, true);
            WriteLiteral("                <div");
            EndContext();
            BeginWriteAttribute("class", " class=\'", 1041, "\'", 1100, 2);
            WriteAttributeValue("", 1049, "col-md-4", 1049, 8, true);
#line 29 "C:\Users\User\Desktop\Vivani Back\Vivani Back\Views\Home\Index.cshtml"
WriteAttributeValue(" ", 1057, i == 1? "my-2 py-3 m-md-0 py-md-0" : "", 1058, 42, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1101, 138, true);
            WriteLiteral(">\n                    <div class=\"item align-items-center\">\n                        <div class=\"left mr-4\">\n                            <i");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1239, "\"", 1289, 2);
#line 32 "C:\Users\User\Desktop\Vivani Back\Vivani Back\Views\Home\Index.cshtml"
WriteAttributeValue("", 1247, Model.whyChooseUs.ElementAt(i).Icon, 1247, 36, false);

#line default
#line hidden
            WriteAttributeValue(" ", 1283, "first", 1284, 6, true);
            EndWriteAttribute();
            BeginContext(1290, 36, true);
            WriteLiteral("></i>\n                            <i");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1326, "\"", 1377, 2);
#line 33 "C:\Users\User\Desktop\Vivani Back\Vivani Back\Views\Home\Index.cshtml"
WriteAttributeValue("", 1334, Model.whyChooseUs.ElementAt(i).Icon, 1334, 36, false);

#line default
#line hidden
            WriteAttributeValue(" ", 1370, "second", 1371, 7, true);
            EndWriteAttribute();
            BeginContext(1378, 163, true);
            WriteLiteral("></i>\n                        </div>\n                        <div class=\"right\">\n                            <div class=\"heading\">\n                                ");
            EndContext();
            BeginContext(1542, 38, false);
#line 37 "C:\Users\User\Desktop\Vivani Back\Vivani Back\Views\Home\Index.cshtml"
                           Write(Model.whyChooseUs.ElementAt(i).Heading);

#line default
#line hidden
            EndContext();
            BeginContext(1580, 118, true);
            WriteLiteral("\n                            </div>\n                            <div class=\"content\">\n                                ");
            EndContext();
            BeginContext(1699, 38, false);
#line 40 "C:\Users\User\Desktop\Vivani Back\Vivani Back\Views\Home\Index.cshtml"
                           Write(Model.whyChooseUs.ElementAt(i).Content);

#line default
#line hidden
            EndContext();
            BeginContext(1737, 117, true);
            WriteLiteral("\n                            </div>\n                        </div>\n                    </div>\n                </div>\n");
            EndContext();
#line 45 "C:\Users\User\Desktop\Vivani Back\Vivani Back\Views\Home\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(1868, 376, true);
            WriteLiteral(@"        </div>
    </div>
</section>
<section id=""trending"">
    <div class=""container"">
        <div class=""row heading"">
            <div class=""col-12"">
                <h1>Ən çox satılan məhsullar</h1>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-lg-4 d-none d-lg-block"">
                <div class=""banner"">
                    ");
            EndContext();
            BeginContext(2244, 102, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c5e5c43dec9f470aacfcbdc613fbdd23", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2254, "~/img/", 2254, 6, true);
#line 59 "C:\Users\User\Desktop\Vivani Back\Vivani Back\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 2260, Model.trendingProductsImage.ElementAtOrDefault(0).ImageUrl, 2260, 59, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2346, 13739, true);
            WriteLiteral(@"
                </div>
            </div>
            <div class=""col-lg-8 col-12 products"">
                <div class=""row"">
                    <div class=""col-sm-6 col-md-4 mt-4 mt-lg-0"">
                        <div class=""item"">
                            <div class=""image-wrapper mb-3"">
                                <div class=""isNew"">
                                    New
                                </div>
                                <div class=""discount"">
                                    -10%
                                </div>
                                <a href="""">
                                    <img src=""img/p1.jpg"" class=""img-fluid"" alt="""">
                                </a>
                                <a href="""" class=""mainBtn"">Daha ətraflı</a>
                            </div>
                            <div class=""content"">
                                <a href="""">
                                    <h1>Tincidunt Ut Laoreet</h1>
                         ");
            WriteLiteral(@"       </a>
                                <p class=""price d-flex justify-content-between"">
                                    340AZN<span class=""old-price"">400AZN</span>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class=""col-sm-6 col-md-4 mt-4 mt-lg-0"">
                        <div class=""item"">
                            <div class=""image-wrapper mb-3"">
                                <div class=""isNew"">
                                    New
                                </div>
                                <a href="""">
                                    <img src=""img/p2.jpg"" class=""img-fluid"" alt="""">
                                </a>
                                <a href="""" class=""mainBtn"">Daha ətraflı</a>
                            </div>
                            <div class=""content"">
                                <a href="""">
                                    <h1>Shrinking F");
            WriteLiteral(@"rom Toil</h1>
                                </a>
                                <p class=""price d-flex justify-content-between"">
                                    340AZN
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class=""col-sm-6 col-md-4 mt-4 mt-lg-0"">
                        <div class=""item"">
                            <div class=""image-wrapper mb-3"">
                                <a href="""">
                                    <img src=""img/p3.jpg"" class=""img-fluid"" alt="""">
                                </a>
                                <a href="""" class=""mainBtn"">Daha ətraflı</a>
                            </div>
                            <div class=""content"">
                                <a href="""">
                                    <h1>Shrinking From Toil</h1>
                                </a>
                                <p class=""price d-flex justify-content-between");
            WriteLiteral(@""">
                                    340AZN
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class=""col-sm-6 col-md-4 mt-4"">
                        <div class=""item"">
                            <div class=""image-wrapper mb-3"">
                                <div class=""isNew"">
                                    New
                                </div>
                                <div class=""discount"">
                                    -10%
                                </div>
                                <a href="""">
                                    <img src=""img/p1.jpg"" class=""img-fluid"" alt="""">
                                </a>
                                <a href="""" class=""mainBtn"">Daha ətraflı</a>
                            </div>
                            <div class=""content"">
                                <a href="""">
                                    <h1>Tincidunt U");
            WriteLiteral(@"t Laoreet</h1>
                                </a>
                                <p class=""price d-flex justify-content-between"">
                                    340AZN<span class=""old-price"">400AZN</span>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class=""col-sm-6 col-md-4 mt-4"">
                        <div class=""item"">
                            <div class=""image-wrapper mb-3"">
                                <div class=""isNew"">
                                    New
                                </div>
                                <a href="""">
                                    <img src=""img/p2.jpg"" class=""img-fluid"" alt="""">
                                </a>
                                <a href="""" class=""mainBtn"">Daha ətraflı</a>
                            </div>
                            <div class=""content"">
                                <a href="""">
                   ");
            WriteLiteral(@"                 <h1>Shrinking From Toil</h1>
                                </a>
                                <p class=""price d-flex justify-content-between"">
                                    340AZN
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class=""col-sm-6 col-md-4 mt-4"">
                        <div class=""item"">
                            <div class=""image-wrapper mb-3"">
                                <a href="""">
                                    <img src=""img/p3.jpg"" class=""img-fluid"" alt="""">
                                </a>
                                <a href="""" class=""mainBtn"">Daha ətraflı</a>
                            </div>
                            <div class=""content"">
                                <a href="""">
                                    <h1>Shrinking From Toil</h1>
                                </a>
                                <p class=""price d-flex");
            WriteLiteral(@" justify-content-between"">
                                    340AZN
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<section id=""popular-products"">
    <div class=""container"">
        <div class=""row heading"">
            <div class=""col-12"">
                <h1>Seçilmiş məhsullar</h1>
                <p>
                    Əl işi ilə işləmiş üzüklər, sırğalar, qolbaqlar və boyunbağıların ən yeni kolleksiyalarından
                    seçilmiş məhsullar.
                </p>
            </div>
        </div>
        <div class=""row mb-2 mb-md-5"">
            <div class=""col-12 categories text-center"">
                <ul class=""d-flex justify-content-center flex-wrap"">
                    <li>
                        <a href="""" data-id=""ring"" class=""active"">Üzüklər</a>
                    </li>
                    <li>
                        <a hr");
            WriteLiteral(@"ef="""" data-id=""earrings"">Sırğalar</a>
                    </li>
                    <li>
                        <a href="""" data-id=""bracelet"">Qolbaqlar</a>
                    </li>
                    <li>
                        <a href="""" data-id=""necklace"">Boyunbağılar</a>
                    </li>
                </ul>
            </div>
        </div>
        <div class=""row content active m-0"" data-id=""ring"">
            <div class=""col-md-6 left-side p-0"">
                <a href="""">
                    <img src=""img/ring.jpg"" width=""100%"" height=""100%"" alt="""">
                </a>
            </div>
            <div class=""col-md-6 right-side d-flex align-items-center p-0"">
                <div class=""info"">
                    <h1>Cartier Love Gold Ring</h1>
                    <p>
                        The DiamondShop Lovely Necklaces collection is a varied and vibrant selection of
                        exceptionally designed pieces adorned with the brand’s renowned precision cut clear and
   ");
            WriteLiteral(@"                     color crystals. Our necklaces can be perfectly matched with a singular.
                    </p>
                    <a class=""mainBtn"" href="""">Daha ətraflı</a>
                </div>
            </div>
        </div>
        <div class=""row content m-0"" style=""display: none;"" data-id=""earrings"">
            <div class=""col-lg-6 left-side p-0"">
                <a href="""">
                    <img src=""img/ear.jpg"" width=""100%"" height=""100%"" alt="""">
                </a>
            </div>
            <div class=""col-lg-6 right-side d-flex align-items-center p-0"">
                <div class=""info"">
                    <h1>Amulette de Cartier</h1>
                    <p>
                        The DiamondShop Lovely Necklaces collection is a varied and vibrant selection of
                        exceptionally designed pieces adorned with the brand’s renowned precision cut clear and
                        color crystals. Our necklaces can be perfectly matched with a singular.
             ");
            WriteLiteral(@"       </p>
                    <a class=""mainBtn"" href="""">Daha ətraflı</a>
                </div>
            </div>
        </div>
        <div class=""row content m-0"" style=""display: none;"" data-id=""bracelet"">
            <div class=""col-lg-6 left-side p-0"">
                <a href="""">
                    <img src=""img/ring.jpg"" width=""100%"" height=""100%"" alt="""">
                </a>
            </div>
            <div class=""col-lg-6 right-side d-flex align-items-center p-0"">
                <div class=""info"">
                    <h1>Cartier Love Gold Ring</h1>
                    <p>
                        The DiamondShop Lovely Necklaces collection is a varied and vibrant selection of
                        exceptionally designed pieces adorned with the brand’s renowned precision cut clear and
                        color crystals. Our necklaces can be perfectly matched with a singular.
                    </p>
                    <a class=""mainBtn"" href="""">Daha ətraflı</a>
                </div>
   ");
            WriteLiteral(@"         </div>
        </div>
        <div class=""row content m-0"" style=""display: none;"" data-id=""necklace"">
            <div class=""col-lg-6 left-side p-0"">
                <a href="""">
                    <img src=""img/neck.jpg"" width=""100%"" height=""100%"" alt="""">
                </a>
            </div>
            <div class=""col-lg-6 right-side d-flex align-items-center p-0"">
                <div class=""info"">
                    <h1>Lovely Necklaces</h1>
                    <p>
                        The DiamondShop Lovely Necklaces collection is a varied and vibrant selection of
                        exceptionally designed pieces adorned with the brand’s renowned precision cut clear and
                        color crystals. Our necklaces can be perfectly matched with a singular.
                    </p>
                    <a class=""mainBtn"" href="""">Daha ətraflı</a>
                </div>
            </div>
        </div>
    </div>
</section>
<section id=""clients"">
    <div class=""container"">
    ");
            WriteLiteral(@"    <div class=""row heading"">
            <div class=""col-12"">
                <h1>Müştəri rəyləri</h1>
            </div>
        </div>
        <div class=""row px-4 px-md-0"">
            <div class=""col-12"">
                <div class=""owl-carousel"">
                    <div class=""item"">
                        <div class=""image-wrapper"">
                            <img src=""img/testimonials-2.jpg"" alt="""">
                        </div>
                        <div class=""heading"">
                            Lenny Stevens
                        </div>
                        <div class=""content"">
                            ""DiamondShop helped me choose a perfect present for my girlfriend’s anniversary. Thank you!""
                        </div>
                    </div>
                    <div class=""item"">
                        <div class=""image-wrapper"">
                            <img src=""img/testimonials-5.jpg"" alt="""">
                        </div>
                        <div class=""heading");
            WriteLiteral(@""">
                            Lenny Stevens
                        </div>
                        <div class=""content"">
                            ""DiamondShop helped me choose a perfect present for my girlfriend’s anniversary. Thank you!""
                        </div>
                    </div>
                    <div class=""item"">
                        <div class=""image-wrapper"">
                            <img src=""img/testimonials-3.jpg"" alt="""">
                        </div>
                        <div class=""heading"">
                            Lenny Stevens
                        </div>
                        <div class=""content"">
                            ""DiamondShop helped me choose a perfect present for my girlfriend’s anniversary. Thank you!""
                        </div>
                    </div>
                    <div class=""item"">
                        <div class=""image-wrapper"">
                            <img src=""img/testimonials-4.jpg"" alt="""">
                        </");
            WriteLiteral(@"div>
                        <div class=""heading"">
                            Lenny Stevens
                        </div>
                        <div class=""content"">
                            ""DiamondShop helped me choose a perfect present for my girlfriend’s anniversary. Thank you!""
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HomeVm> Html { get; private set; }
    }
}
#pragma warning restore 1591