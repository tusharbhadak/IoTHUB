#pragma checksum "C:\Users\Tushar\source\repos\IoTHUB v1.0\Views\Account\Viewadmin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c879b6687126a1903797a7b2efdf172f37056bd4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Viewadmin), @"mvc.1.0.view", @"/Views/Account/Viewadmin.cshtml")]
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
#line 1 "C:\Users\Tushar\source\repos\IoTHUB v1.0\Views\_ViewImports.cshtml"
using IoTHUB_v1._0;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Tushar\source\repos\IoTHUB v1.0\Views\_ViewImports.cshtml"
using IoTHUB_v1._0.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Tushar\source\repos\IoTHUB v1.0\Views\Account\Viewadmin.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c879b6687126a1903797a7b2efdf172f37056bd4", @"/Views/Account/Viewadmin.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6f550c6c2df213f796a776decb67f955a1ea1e59", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Viewadmin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("NJ"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:60%"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c879b6687126a1903797a7b2efdf172f37056bd44267", async() => {
                WriteLiteral(@"
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"">
    <style>
        .card {
            box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
            max-width: 500px;
            margin: auto;
            text-align: center;
            font-family: arial;
        }
        .card img {
                align-self: center
        }
        .title {
            color: grey;
            font-size: 18px;
        }

        button {
            border: none;
            outline: 0;
            display: inline-block;
            padding: 8px;
            color: white;
            background-color: green;
            text-align: center;
            cursor: pointer;
            width: 100%;
            font-size: 18px;
        }

        a {
            text-decoration: none;
            font-size: 22px;
            color: black;
        }

            button:hover, a:hover {
                opacity: 0.7;
         ");
                WriteLiteral("   }\r\n    </style>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c879b6687126a1903797a7b2efdf172f37056bd46317", async() => {
                WriteLiteral("\r\n\r\n    <h2 style=\"text-align:center\">Profile</h2>\r\n\r\n    <div class=\"card\">\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c879b6687126a1903797a7b2efdf172f37056bd46671", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 1221, "~/Images/", 1221, 9, true);
#nullable restore
#line 51 "C:\Users\Tushar\source\repos\IoTHUB v1.0\Views\Account\Viewadmin.cshtml"
AddHtmlAttributeValue("", 1230, Context.Session.GetString("Mediapath"), 1230, 39, false);

#line default
#line hidden
#nullable disable
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
                WriteLiteral("\r\n        <h1>");
#nullable restore
#line 52 "C:\Users\Tushar\source\repos\IoTHUB v1.0\Views\Account\Viewadmin.cshtml"
       Write(Context.Session.GetString("Username"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</h1>\r\n\r\n        <p>Username       :- ");
#nullable restore
#line 54 "C:\Users\Tushar\source\repos\IoTHUB v1.0\Views\Account\Viewadmin.cshtml"
                        Write(Context.Session.GetString("Username"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n        <p>Email\t\t\t:- ");
#nullable restore
#line 55 "C:\Users\Tushar\source\repos\IoTHUB v1.0\Views\Account\Viewadmin.cshtml"
                          Write(Context.Session.GetString("Email"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n        <p>Mobile No\t\t:- ");
#nullable restore
#line 56 "C:\Users\Tushar\source\repos\IoTHUB v1.0\Views\Account\Viewadmin.cshtml"
                          Write(Context.Session.GetString("PhoneNo"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n        <p>Address\t\t:- ");
#nullable restore
#line 57 "C:\Users\Tushar\source\repos\IoTHUB v1.0\Views\Account\Viewadmin.cshtml"
                        Write(Context.Session.GetString("Address"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n        <p>Company name\t:- ");
#nullable restore
#line 58 "C:\Users\Tushar\source\repos\IoTHUB v1.0\Views\Account\Viewadmin.cshtml"
                         Write(Context.Session.GetString("Companyname"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n        <p>Company email\t:- ");
#nullable restore
#line 59 "C:\Users\Tushar\source\repos\IoTHUB v1.0\Views\Account\Viewadmin.cshtml"
                          Write(Context.Session.GetString("Companyemail"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n        <p><button>Back</button></p>\r\n    </div>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
