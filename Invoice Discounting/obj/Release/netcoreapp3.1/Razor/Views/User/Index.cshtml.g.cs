#pragma checksum "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c01d71c5f8040ee513f2fb5e61f30a99a81e5b62"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Index), @"mvc.1.0.view", @"/Views/User/Index.cshtml")]
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
#line 1 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\_ViewImports.cshtml"
using Invoice_Discounting;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\_ViewImports.cshtml"
using Invoice_Discounting.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\_ViewImports.cshtml"
using Invoice_Discounting.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c01d71c5f8040ee513f2fb5e61f30a99a81e5b62", @"/Views/User/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e7e6c2b2e2093347ee78387d906f49a77b633a7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_User_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserPendingApproveModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/images/plus-icon.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/images/edit.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("mr-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml"
  
    ViewData["Title"] = "User Management";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row mt-4"">
    <div class=""col-12 d-flex justify-content-between align-items-center"">
        <div class=""search-group"" id=""dvallusers"">
            <input type=""text"" style=""width: 300px;"" placeholder=""search"" id=""txtallusers"" class=""form-control pl-5""
                   aria-label=""Text input with checkbox"">
            <i class=""fa fa-search""></i>
        </div>
        <div class=""search-group"" id=""dvuserrequest"" style=""display:none"">
            <input type=""text"" style=""width: 300px;"" placeholder=""search"" id=""txtuserrequest"" class=""form-control pl-5""
                   aria-label=""Text input with checkbox"">
            <i class=""fa fa-search""></i>
        </div>
        <div>

            <div>
                <button type=""button"" class=""btn btn-outline-primary blue-outline-btn"" id=""lnkCreate"">
                    Create New ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c01d71c5f8040ee513f2fb5e61f30a99a81e5b625768", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </button>\r\n\r\n");
            WriteLiteral(@"            </div>
        </div>
    </div>
</div>

<div class=""row my-5"">
    <div class=""col-12"">
        <ul class=""nav nav-tabs mb-4 border-bottom-0"" id=""myTab"" role=""tablist"">
            <li class=""nav-item"" role=""presentation"">
                <button class=""nav-link active tab-btn "" id=""all-users-tab"" data-toggle=""tab""
                        data-target=""#all-users"" type=""button"" role=""tab"" aria-controls=""all-users""
                        aria-selected=""true"">
                    All Users
                </button>
            </li>
            <li class=""nav-item"" role=""presentation"">
                <button class=""nav-link tab-btn"" id=""user-requests-tab"" data-toggle=""tab""
                        data-target=""#user-requests"" type=""button"" role=""tab""
                        aria-controls=""user-requests"" aria-selected=""false"">
                    New User Request
                </button>
            </li>

        </ul>

        <div class=""tab-content"" id=""myTabContent"">
");
            WriteLiteral(@"            <div class=""card my-card tab-pane active"" id=""all-users"">
                <div class=""card-body px-0"">
                    <div class=""header px-4 pb-3 d-flex justify-content-between align-items-center"">
                        <h5 class=""card-title mb-0"">Users List</h5>

                    </div>

                    <div class=""notif-wrapper p-4 notif-card "" style=""height: 55vh;"">
                        <table id=""users"" class=""table example "" style=""width:100%"">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>UserName</th>
                                    <th>Email</th>
                                    <th>First Name</th>
                                    <th>Last Name</th>
                                    <th>Initiator</th>
                                    <th>Date Initiated</th>
                                    <th>Status</th>
                   ");
            WriteLiteral("                 <th></th>\r\n\r\n                                </tr>\r\n                            </thead>\r\n                            <tbody>\r\n");
#nullable restore
#line 78 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml"
                                   int i = 1; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 79 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml"
                                 if (Model.userapproved == null)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td colspan=\"8\">No Record Found</td>\r\n                                    </tr>\r\n");
#nullable restore
#line 84 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml"
                                }
                                else
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 87 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml"
                                     foreach (var item in Model.userapproved)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <td>\r\n                                                <label> ");
#nullable restore
#line 91 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml"
                                                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </label>\r\n");
#nullable restore
#line 92 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml"
                                                   i++; 

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 95 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml"
                                           Write(Html.ActionLink(item.USERNAME, "ViewUserDetailsModal", new { userId = item.ID }, new { @class = "link blue", @id = "lnkcontract" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 98 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.EMAIL));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n\r\n\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 103 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.FIRSTNAME));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 106 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.LASTNAME));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 109 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.INPUTTERNAME));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 112 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.CREATEDDATE));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                            </td>
                                            <td>
                                                <label class=""switch"">
                                                    <input type=""checkbox"" checked>
                                                    <span class=""slider round""></span>
                                                </label>
                                            </td>
                                            
                                            <td>
                                               <a");
            BeginWriteAttribute("href", " href=\"", 6061, "\"", 6123, 1);
#nullable restore
#line 122 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml"
WriteAttributeValue("", 6068, Url.Action("ModifyUser", "User", new { id = item.ID }), 6068, 55, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"edit\">\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c01d71c5f8040ee513f2fb5e61f30a99a81e5b6215531", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                </a>\r\n                                            </td>\r\n\r\n                                        </tr>\r\n");
#nullable restore
#line 128 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 128 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml"
                                     

                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </tbody>
                        </table>

                    </div>
                    
                </div>
            </div>


            <div class=""card my-card tab-pane"" id=""user-requests"">
                <div class=""card-body px-0"">
                    <div class=""header px-4 pb-3 d-flex justify-content-between align-items-center"">
                        <h5 class=""card-title mb-0"">Users Requested</h5>

                    </div>

                    <div class=""notif-wrapper p-4 notif-card "" style=""height: 55vh;"">

                        <table id=""userrequests"" class=""table  example"" style=""width:100%"">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>UserName</th>
                                    <th>Email</th>
                                    <th>First Name</th>
                                    <th>Last Name</th>
      ");
            WriteLiteral("                              <th>Initiator</th>\r\n                                    <th>Date Initiated</th>\r\n                                </tr>\r\n                            </thead>\r\n                            <tbody>\r\n");
#nullable restore
#line 162 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml"
                                   int j = 1; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 163 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml"
                                 if (Model.userpending == null)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td colspan=\"8\">No Record Found</td>\r\n                                    </tr>\r\n");
#nullable restore
#line 168 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml"
                                }
                                else
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 171 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml"
                                     foreach (var item in Model.userpending)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    <label> ");
#nullable restore
#line 175 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml"
                                       Write(j);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </label>\r\n");
#nullable restore
#line 176 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml"
                                       j++; 

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 179 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml"
                               Write(Html.ActionLink(item.USERNAME, "ViewUserDetailsApprovalModal", new { userId = item.ID }, new { @class = "link blue", @id = "lnkviewuser" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n\r\n                                <td>\r\n                                    ");
#nullable restore
#line 183 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.EMAIL));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 186 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.FIRSTNAME));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 189 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.LASTNAME));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 192 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.INPUTTERNAME));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 195 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.CREATEDDATE));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n\r\n                            </tr>\r\n");
#nullable restore
#line 199 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 199 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml"
                                     

                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </tbody>
                        </table>

                    </div>



                </div>
            </div>
        </div>
    </div>
</div>



<div id=""editModal""></div>
<div id=""detailsModal""></div>
<div id=""cmodal""></div>
<div id=""userviewmodal""></div>
");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {

            $('#userrequests').DataTable({
                dom: 'lrtip',
                order: [],
                paging: true,
                info: true
            });
            $('#users').DataTable({
                dom: 'lrtip',
                order: [],
                paging: true,
                info: true,
                buttons: [
                    {
                        extend: 'excel',
                        className: 'excel',
                        text: '<i class=""fas fa-file-excel""></i>',
                        footer: true,
                        titleAttr: 'Excel'
                    },
                    {
                        extend: 'pdf',
                        text: '<i class=""fas fa-file-pdf""></i>',
                        titleAttr: 'PDF'
                    }
                ]
            });

        });
        
        //$(""a.edit"").on('click', function () {
        //   ");
                WriteLiteral(@" $.ajax({
        //        url: this.href,
        //        type: 'Get',
        //        cache: true,
        //        success: function (result) {
        //            $('#editModal').html(result).find('.modal').modal({
        //                show: true
        //            });
        //        }
        //    });
        //    return false;
        //});
        
        $(""a.link"").on('click', function () {
            $.ajax({
                url: this.href,
                type: 'Get',
                cache: true,
                success: function (result) {
                    $('#userviewmodal').html(result).find('.modal').modal({
                        show: true
                    });
                }

            });
            return false;
        });

        $(""#lnkCreate"").on('click', function () {
            window.location.href = '");
#nullable restore
#line 285 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\Index.cshtml"
                               Write(Url.Action("_AddUser", "User"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"';           
        });

        $('#txtallusers').on('keyup', function () {

            var searchTxt = $(""#txtallusers"").val();
            $('#users').DataTable().search(searchTxt).draw();
        });

        $('#txtuserrequest').on('keyup', function () {

            var searchTxt = $(""#txtuserrequest"").val();
            $('#userrequests').DataTable().search(searchTxt).draw();
        });

        $('button[data-toggle=""tab""]').on('shown.bs.tab', function (e) {

            var target = $(e.target).attr(""data-target""); // activated tab
            if (target == ""#user-requests"") {
                $(""#dvuserrequest"").show();
                $(""#dvallusers"").hide();

            } else {
                $(""#dvuserrequest"").hide();
                $(""#dvallusers"").show();
            }
        });
    </script>
");
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserPendingApproveModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591