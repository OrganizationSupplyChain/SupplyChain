#pragma checksum "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Role\Index - Copy.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cbc4f16cfffd2e8c7b58e78fe660cacb11d63496"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Role_Index___Copy), @"mvc.1.0.view", @"/Views/Role/Index - Copy.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cbc4f16cfffd2e8c7b58e78fe660cacb11d63496", @"/Views/Role/Index - Copy.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e7e6c2b2e2093347ee78387d906f49a77b633a7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Role_Index___Copy : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RoleViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Role\Index - Copy.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""container-fluid"">
    <!-- Page Heading -->
    <div class=""row"">
        <div class=""col-md-6"">
            <h1 class=""h3 mb-2 text-gray-800"">Role Management</h1>
        </div>

        <div class=""col-md-6"" style=""text-align:right"">
            <a id=""lnkCreate"" class=""btn btn-success btn-icon-split"">
                <span class=""icon text-white-50"">
                    <i class=""fas fa-plus"" style=""color:white""></i>
                </span>
                <span class=""text"" style=""color:white"">Add New Role</span>
            </a>
        </div>
    </div>
    <p><label style=""color:red"">");
#nullable restore
#line 26 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Role\Index - Copy.cshtml"
                           Write(Html.TempData["message"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label></p>

    <div class=""card shadow mb-4"">
        <div class=""card-header py-3"">
            <h6 class=""m-0 font-weight-bold text-primary"">Role List</h6>
        </div>
        <div class=""card-body"">
            <div class=""table-responsive"">
                <table class=""table table-bordered"" id=""example"" width=""100%"" style=""font-family:Calibri; font-size: 14px;"" cellspacing=""0"">
                    <thead>
                        <tr style=""background-color:lightgrey; color:black"">
                            <th>Role Name</th>
                            <th>Modules</th>
                            <th>Status</th>
                            <th>Creator</th>
                            <th>Date Created</th>
                            <th></th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 47 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Role\Index - Copy.cshtml"
                         if (Model.Roles != null)
                        {
                            foreach (var item in Model.Roles)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 53 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Role\Index - Copy.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.ROLENAME));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 56 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Role\Index - Copy.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.MODULES));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n");
#nullable restore
#line 59 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Role\Index - Copy.cshtml"
                                         if (item.STATUS == '1')
                                        {
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 61 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Role\Index - Copy.cshtml"
                                       Write(Html.Label("ACTIVE"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 61 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Role\Index - Copy.cshtml"
                                                                 
                                        }
                                        else
                                        {
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Role\Index - Copy.cshtml"
                                       Write(Html.Label("DISABLED"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Role\Index - Copy.cshtml"
                                                                   
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 70 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Role\Index - Copy.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.CREATORNAME));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 73 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Role\Index - Copy.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.CREATEDDATE));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td style=\"width:120px\">\r\n                                        ");
#nullable restore
#line 76 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Role\Index - Copy.cshtml"
                                   Write(Html.ActionLink("Edit", "ModifyRole", new { id = item.ID }, new { @class = "edit" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                    </td>\r\n                                    <td style=\"width:120px\">\r\n                                        ");
#nullable restore
#line 80 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Role\Index - Copy.cshtml"
                                   Write(Html.ActionLink("View", "_Details", new { id = item.ID }, new { @class = "view" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 83 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Role\Index - Copy.cshtml"
                            }
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <!-- .col -->\r\n</div>\r\n<div id=\"editModal\"></div>\r\n<div id=\"detailsModal\"></div>\r\n<div id=\"cmodal\"></div>\r\n");
            WriteLiteral("\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $('#example').DataTable({
                dom: 'Bfrtip',
                order: [],
                buttons: [

                    //{
                    //    extend: 'copy',
                    //    text: '<i class=""fas fa-copy""></i>',
                    //    titleAttr: 'Copy'
                    //},
                    {
                        extend: 'excel',
                        className: 'excel',
                        text: '<i class=""fas fa-file-excel""></i>',
                        footer: true,
                        titleAttr: 'Excel'
                    },
                    //{
                    //    extend: 'csv',
                    //    text: '<i class=""fas fa-file-csv""></i>',
                    //    titleAttr: 'CSV'
                    //},
                    {
                        extend: 'pdf',
                        text: '<i class=""fas fa-file-pdf""></i>',
                ");
                WriteLiteral(@"        titleAttr: 'PDF'
                    }
                ]
            });
        });
        $('#clear').click(function () {

            $('#stats').val('').attr(""selected"", '');
            $('#roles').val('').attr(""selected"", '');
            var roles = $(""#roles"").val();
            var stats = $(""#stats"").val();
            $('#example').DataTable().column(0).search(roles).draw();
            $('#example').DataTable().column(5).search(stats).draw();
        });
        $('#roles').change(function () {
            var roles = $(""#roles"").val();
            $('#example').DataTable().column(0).search(roles).draw();
        })
        $('#stats').change(function () {
            var stats = $(""#stats"").val();
            $('#example').DataTable().column(5).search(stats).draw();
        })

        $(""a.edit"").on('click', function () {
            $.ajax({
                url: this.href,
                type: 'Get',
                cache: true,
                success: fun");
                WriteLiteral(@"ction (result) {
                    $('#editModal').html(result).find('.modal').modal({
                        show: true
                    });
                }
            });
            return false;
        });
        $(""a.view"").on('click', function () {
            $.ajax({
                url: this.href,
                type: 'Get',
                cache: true,
                success: function (result) {
                    $('#detailsModal').html(result).find('.modal').modal({
                        show: true
                    });
                }

            });
            return false;
        });
        $(""#lnkCreate"").on('click', function () {
            var u = '/Role/AddRole';
            $.ajax({
                url: u,
                type: 'Get',
                cache: true,
                success: function (result) {
                    $('#cmodal').html(result).find('.modal').modal({
                        show: true
                    });
");
                WriteLiteral("                }\r\n            });\r\n            return false;\r\n        });\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RoleViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
