#pragma checksum "C:\GitHub\MyLearnigStatus\client-app\Views\Guide\MyProjects.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2f7c2064ee541c44dbe614d20b748883a97848f1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Guide_MyProjects), @"mvc.1.0.view", @"/Views/Guide/MyProjects.cshtml")]
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
#line 1 "C:\GitHub\MyLearnigStatus\client-app\Views\_ViewImports.cshtml"
using LearnSchoolApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\GitHub\MyLearnigStatus\client-app\Views\_ViewImports.cshtml"
using LearnSchoolApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2f7c2064ee541c44dbe614d20b748883a97848f1", @"/Views/Guide/MyProjects.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc90891c26ffc4872a0590a1975d76b87bda582a", @"/Views/_ViewImports.cshtml")]
    public class Views_Guide_MyProjects : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LearnSchoolApp.Entities.Project>>
    {
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2f7c2064ee541c44dbe614d20b748883a97848f13243", async() => {
                WriteLiteral(@"
    <style>
        body {
            text-align: left;
            background-image: url(https://wallpapercave.com/wp/wp5306486.jpg);
            background-position: center;
            background-repeat: no-repeat;
            background-size: cover;
        }

        footer {
            background-color: #ddc4a8de;
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2f7c2064ee541c44dbe614d20b748883a97848f14995", async() => {
                WriteLiteral("\r\n    <div class=\"text-center\">\r\n        <h4>פרויקטים</h4>\r\n        <hr />\r\n");
#nullable restore
#line 45 "C:\GitHub\MyLearnigStatus\client-app\Views\Guide\MyProjects.cshtml"
         if (TempData["AlertMessage"] != null)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"alert alert-success\">\r\n                <i>");
#nullable restore
#line 48 "C:\GitHub\MyLearnigStatus\client-app\Views\Guide\MyProjects.cshtml"
              Write(TempData["AlertMessage"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</i>\r\n            </div>\r\n");
#nullable restore
#line 50 "C:\GitHub\MyLearnigStatus\client-app\Views\Guide\MyProjects.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"    </div>
    <center>
        <table class=""table text-center"">
            <thead>
                <tr>
                    <th>
                        פרויקט מס
                    </th>
                    <th>
                        שם פרויקט
                    </th>
                    <th>
                        סטודנטים בפרויקט
                    </th>
                    <th>
                        פרויקט סטטוס
                    </th>
                    <th>
                        הנחיות ראש המגמה
                    </th>
                    <th>
                        הנחיות המנחה
                    </th>
                    <th>
                        הצעת פרויקט
                    </th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 80 "C:\GitHub\MyLearnigStatus\client-app\Views\Guide\MyProjects.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 84 "C:\GitHub\MyLearnigStatus\client-app\Views\Guide\MyProjects.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 87 "C:\GitHub\MyLearnigStatus\client-app\Views\Guide\MyProjects.cshtml"
                       Write(Html.DisplayFor(modelItem => item.name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            <ol>\r\n                                <li>\r\n                                    <details>\r\n                                        <summary>");
#nullable restore
#line 93 "C:\GitHub\MyLearnigStatus\client-app\Views\Guide\MyProjects.cshtml"
                                            Write(Html.DisplayFor(modelItem => item.studentName));

#line default
#line hidden
#nullable disable
                WriteLiteral("</summary>\r\n                                        ");
#nullable restore
#line 94 "C:\GitHub\MyLearnigStatus\client-app\Views\Guide\MyProjects.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.studentId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    </details>\r\n                                </li>\r\n");
#nullable restore
#line 97 "C:\GitHub\MyLearnigStatus\client-app\Views\Guide\MyProjects.cshtml"
                                 if (item.assistantStudentName != null)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <li>\r\n                                        <details>\r\n                                            <summary>");
#nullable restore
#line 101 "C:\GitHub\MyLearnigStatus\client-app\Views\Guide\MyProjects.cshtml"
                                                Write(Html.DisplayFor(modelItem => item.assistantStudentName));

#line default
#line hidden
#nullable disable
                WriteLiteral("</summary>\r\n                                            ");
#nullable restore
#line 102 "C:\GitHub\MyLearnigStatus\client-app\Views\Guide\MyProjects.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.assistantStudentId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                        </details>\r\n                                    </li>\r\n");
#nullable restore
#line 105 "C:\GitHub\MyLearnigStatus\client-app\Views\Guide\MyProjects.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            </ol>\r\n                        </td>\r\n                        <td>\r\n");
#nullable restore
#line 109 "C:\GitHub\MyLearnigStatus\client-app\Views\Guide\MyProjects.cshtml"
                              
                                if (item.isPass)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <i><b><label><ins>מאושר</ins></label></b></i>\r\n");
#nullable restore
#line 113 "C:\GitHub\MyLearnigStatus\client-app\Views\Guide\MyProjects.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <i><b><label><ins>לא מאושר</ins></label></b></i>\r\n");
#nullable restore
#line 117 "C:\GitHub\MyLearnigStatus\client-app\Views\Guide\MyProjects.cshtml"
                                }
                            

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </td>\r\n                        <td>\r\n                            <div>");
#nullable restore
#line 121 "C:\GitHub\MyLearnigStatus\client-app\Views\Guide\MyProjects.cshtml"
                            Write(Html.ActionLink("פרטים", "ProjectStatus","Project", new { id = item.Id }));

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                        </td>\r\n                        <td>\r\n                            <div>");
#nullable restore
#line 124 "C:\GitHub\MyLearnigStatus\client-app\Views\Guide\MyProjects.cshtml"
                            Write(Html.ActionLink("פרטים", "ProjectStatus", new { id = item.Id }));

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n");
#nullable restore
#line 125 "C:\GitHub\MyLearnigStatus\client-app\Views\Guide\MyProjects.cshtml"
                             if (User.IsInRole("Guid"))
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <div>");
#nullable restore
#line 127 "C:\GitHub\MyLearnigStatus\client-app\Views\Guide\MyProjects.cshtml"
                                Write(Html.ActionLink("הוספת הנחיה", "CreateStauts", new { id = item.Id }));

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n");
#nullable restore
#line 128 "C:\GitHub\MyLearnigStatus\client-app\Views\Guide\MyProjects.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </td>\r\n                        <td>\r\n                            Z\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 134 "C:\GitHub\MyLearnigStatus\client-app\Views\Guide\MyProjects.cshtml"
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
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LearnSchoolApp.Entities.Project>> Html { get; private set; }
    }
}
#pragma warning restore 1591
