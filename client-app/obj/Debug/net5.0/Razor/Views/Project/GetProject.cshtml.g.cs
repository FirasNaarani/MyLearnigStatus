#pragma checksum "D:\GitHub\MyLearnigStatus\client-app\Views\Project\GetProject.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "924de6b7a20759f7b629b817c07288b15c0eba32"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Project_GetProject), @"mvc.1.0.view", @"/Views/Project/GetProject.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"924de6b7a20759f7b629b817c07288b15c0eba32", @"/Views/Project/GetProject.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc90891c26ffc4872a0590a1975d76b87bda582a", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Project_GetProject : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LearnSchoolApp.Entities.Project>
    #nullable disable
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "924de6b7a20759f7b629b817c07288b15c0eba323286", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "924de6b7a20759f7b629b817c07288b15c0eba325097", async() => {
                WriteLiteral("\r\n    <div class=\"text-center\">\r\n        <h4>פרויקט</h4>\r\n        <hr />\r\n    </div>\r\n    <center>\r\n        <table class=\"table\">\r\n            <tbody>\r\n                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 46 "D:\GitHub\MyLearnigStatus\client-app\Views\Project\GetProject.cshtml"
                   Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        <b>מס\' פרויקט</b>\r\n                    </td>\r\n                </tr>\r\n\r\n                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 55 "D:\GitHub\MyLearnigStatus\client-app\Views\Project\GetProject.cshtml"
                   Write(Html.DisplayFor(model => model.name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        <b> שם פרויקט</b>\r\n                    </td>\r\n                </tr>\r\n\r\n                <tr>\r\n                    <td>\r\n");
#nullable restore
#line 64 "D:\GitHub\MyLearnigStatus\client-app\Views\Project\GetProject.cshtml"
                          
                            if (Model.guideId != null)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 67 "D:\GitHub\MyLearnigStatus\client-app\Views\Project\GetProject.cshtml"
                           Write(Html.ActionLink("פרטים", "GetGuide", new { id = Model.guideId }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 67 "D:\GitHub\MyLearnigStatus\client-app\Views\Project\GetProject.cshtml"
                                                                                                 
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <label>---</label>\r\n");
#nullable restore
#line 72 "D:\GitHub\MyLearnigStatus\client-app\Views\Project\GetProject.cshtml"
                            }
                        

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    </td>
                    <td>
                        <b>מנחה</b>
                    </td>
                </tr>

                <tr>
                    <td>
                        <ol>
                            <li>
                                <b>");
#nullable restore
#line 84 "D:\GitHub\MyLearnigStatus\client-app\Views\Project\GetProject.cshtml"
                              Write(Html.DisplayFor(model => model.studentId));

#line default
#line hidden
#nullable disable
                WriteLiteral(" | ");
#nullable restore
#line 84 "D:\GitHub\MyLearnigStatus\client-app\Views\Project\GetProject.cshtml"
                                                                           Write(Html.DisplayFor(model => model.studentName));

#line default
#line hidden
#nullable disable
                WriteLiteral("</b>\r\n                            </li>\r\n");
#nullable restore
#line 86 "D:\GitHub\MyLearnigStatus\client-app\Views\Project\GetProject.cshtml"
                             if (Model.assistantStudentName != null)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <li>\r\n                                    <b>");
#nullable restore
#line 89 "D:\GitHub\MyLearnigStatus\client-app\Views\Project\GetProject.cshtml"
                                  Write(Html.DisplayFor(model => model.assistantStudentId));

#line default
#line hidden
#nullable disable
                WriteLiteral(" | ");
#nullable restore
#line 89 "D:\GitHub\MyLearnigStatus\client-app\Views\Project\GetProject.cshtml"
                                                                                        Write(Html.DisplayFor(model => model.assistantStudentName));

#line default
#line hidden
#nullable disable
                WriteLiteral("</b>\r\n                                </li>\r\n");
#nullable restore
#line 91 "D:\GitHub\MyLearnigStatus\client-app\Views\Project\GetProject.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </ol>\r\n                    </td>\r\n                    <td>\r\n                        <b>סטודנטים בפרויקט</b>\r\n                    </td>\r\n                </tr>\r\n\r\n                <tr>\r\n                    <td>\r\n");
#nullable restore
#line 101 "D:\GitHub\MyLearnigStatus\client-app\Views\Project\GetProject.cshtml"
                          
                            if (Model.isPass)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <i><b><label><ins>מאושר</ins></label></b></i>\r\n");
#nullable restore
#line 105 "D:\GitHub\MyLearnigStatus\client-app\Views\Project\GetProject.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <i><b><label><ins>לא מאושר</ins></label></b></i>\r\n");
#nullable restore
#line 109 "D:\GitHub\MyLearnigStatus\client-app\Views\Project\GetProject.cshtml"
                            }
                        

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </td>\r\n                    <td>\r\n                        <b>פרויקט סטטוס</b>\r\n                    </td>\r\n                </tr>\r\n\r\n                <tr>\r\n                    <td>\r\n");
#nullable restore
#line 119 "D:\GitHub\MyLearnigStatus\client-app\Views\Project\GetProject.cshtml"
                          
                            if (Model.guidingStatuses.Count() > 0)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 122 "D:\GitHub\MyLearnigStatus\client-app\Views\Project\GetProject.cshtml"
                           Write(Html.ActionLink("פרטים", "ProjectStatus", "Student", new { id = Model.Id }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 122 "D:\GitHub\MyLearnigStatus\client-app\Views\Project\GetProject.cshtml"
                                                                                                            
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <i><b><label><ins>עדיין אין הנחיות</ins></label></b></i>\r\n");
#nullable restore
#line 127 "D:\GitHub\MyLearnigStatus\client-app\Views\Project\GetProject.cshtml"
                            }
                        

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </td>\r\n                    <td>\r\n                        <b>הנחיות המנחה</b>\r\n                    </td>\r\n                </tr>\r\n\r\n                <tr>\r\n                    <td>\r\n");
#nullable restore
#line 137 "D:\GitHub\MyLearnigStatus\client-app\Views\Project\GetProject.cshtml"
                          
                            if (Model.projectStatuses.Count() > 0)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 140 "D:\GitHub\MyLearnigStatus\client-app\Views\Project\GetProject.cshtml"
                           Write(Html.ActionLink("פרטים", "ProjectStatus", new { id = Model.Id }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 140 "D:\GitHub\MyLearnigStatus\client-app\Views\Project\GetProject.cshtml"
                                                                                                 
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <i><b><label><ins>עדיין אין הנחיות</ins></label></b></i>\r\n");
#nullable restore
#line 145 "D:\GitHub\MyLearnigStatus\client-app\Views\Project\GetProject.cshtml"
                            }


                        

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </td>\r\n                    <td>\r\n                        <b>הנחיות ראש המגמה</b>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 154 "D:\GitHub\MyLearnigStatus\client-app\Views\Project\GetProject.cshtml"
                  
                    if (User.IsInRole("Student"))
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\r\n                            <td>\r\n");
#nullable restore
#line 159 "D:\GitHub\MyLearnigStatus\client-app\Views\Project\GetProject.cshtml"
                                  
                                    if (Model.isPass)
                                    {
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 162 "D:\GitHub\MyLearnigStatus\client-app\Views\Project\GetProject.cshtml"
                                   Write(Html.ActionLink("צפיה", "FileView", new { id = Model.studentId }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 162 "D:\GitHub\MyLearnigStatus\client-app\Views\Project\GetProject.cshtml"
                                                                                                          
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <i><b><label><ins>עדיין לא התקבל אישור על הצעת פרויקט</ins></label></b></i>\r\n");
#nullable restore
#line 167 "D:\GitHub\MyLearnigStatus\client-app\Views\Project\GetProject.cshtml"
                                    }
                                

#line default
#line hidden
#nullable disable
                WriteLiteral("                            </td>\r\n                            <td>\r\n                                <b>הצעת פרויקט</b>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 174 "D:\GitHub\MyLearnigStatus\client-app\Views\Project\GetProject.cshtml"
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
            WriteLiteral("\r\n</html>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LearnSchoolApp.Entities.Project> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
