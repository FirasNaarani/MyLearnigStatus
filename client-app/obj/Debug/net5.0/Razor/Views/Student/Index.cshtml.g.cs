#pragma checksum "D:\GitHub\MyLearnigStatus\client-app\Views\Student\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fa2a68db3bbf23c5bc004fc3208fab83ffb7a195"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_Index), @"mvc.1.0.view", @"/Views/Student/Index.cshtml")]
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
#line 1 "D:\GitHub\MyLearnigStatus\client-app\Views\_ViewImports.cshtml"
using LearnSchoolApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\GitHub\MyLearnigStatus\client-app\Views\_ViewImports.cshtml"
using LearnSchoolApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa2a68db3bbf23c5bc004fc3208fab83ffb7a195", @"/Views/Student/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc90891c26ffc4872a0590a1975d76b87bda582a", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Student_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LearnSchoolApp.Entities.Student>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fa2a68db3bbf23c5bc004fc3208fab83ffb7a1953711", async() => {
                WriteLiteral(@"
    <style>
        body {
            text-align: left;
            background-image: url(https://media.istockphoto.com/vectors/watercolor-seamless-background-with-green-hexagon-tiles-vector-id1212124417?k=20&m=1212124417&s=612x612&w=0&h=DQ_M1UGj4e2JiJDs8SGJ3RgIk_8myxNuGtyb2OKQFeI=);
            background-position: center;
            background-repeat: no-repeat;
            background-size: cover;
        }

        footer {
            background: rgb(255 255 255 / 80%);
        }

        table {
            box-shadow: 0 10px 10px #033740;
        }

        td {
            text-align: center;
            padding: 8px;
        }

        th {
            background-color: white;
            text-align: center;
        }

        tr:nth-child(even) {
            background-color: #D6EEEE;
        }

        tr:nth-child(2n+1) {
            background-color: #a2dbcb;
        }
    </style>
");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fa2a68db3bbf23c5bc004fc3208fab83ffb7a1955620", async() => {
                WriteLiteral("\r\n    <div class=\"text-center\">\r\n        <h4>סטודנטים</h4>\r\n        <hr />\r\n        <p>\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fa2a68db3bbf23c5bc004fc3208fab83ffb7a1955987", async() => {
                    WriteLiteral("הוספת סטודנט חדש");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        </p>\r\n");
#nullable restore
#line 49 "D:\GitHub\MyLearnigStatus\client-app\Views\Student\Index.cshtml"
         if (TempData["AlertMessage"] != null)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"alert alert-success\">\r\n                <i>");
#nullable restore
#line 52 "D:\GitHub\MyLearnigStatus\client-app\Views\Student\Index.cshtml"
              Write(TempData["AlertMessage"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</i>\r\n            </div>\r\n");
#nullable restore
#line 54 "D:\GitHub\MyLearnigStatus\client-app\Views\Student\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"    </div>
    <center>
        <table class=""table"">
            <thead>
                <tr>
                    <th></th>
                    <th>
                        מס' טלפון
                    </th>
                    <th>
                        מייל
                    </th>
                    <th>
                        שם משתמש
                    </th>
                    <th>
                        שם
                    </th>
                    <th>
                        ת""ז
                    </th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 79 "D:\GitHub\MyLearnigStatus\client-app\Views\Student\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 83 "D:\GitHub\MyLearnigStatus\client-app\Views\Student\Index.cshtml"
                       Write(Html.ActionLink("פרטים", "Details", new { id = item.userId }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 86 "D:\GitHub\MyLearnigStatus\client-app\Views\Student\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.phone));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 89 "D:\GitHub\MyLearnigStatus\client-app\Views\Student\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.email));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 92 "D:\GitHub\MyLearnigStatus\client-app\Views\Student\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.username));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 95 "D:\GitHub\MyLearnigStatus\client-app\Views\Student\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 98 "D:\GitHub\MyLearnigStatus\client-app\Views\Student\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.userId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 101 "D:\GitHub\MyLearnigStatus\client-app\Views\Student\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </tbody>\r\n        </table>\r\n    </center>\r\n");
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
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LearnSchoolApp.Entities.Student>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
