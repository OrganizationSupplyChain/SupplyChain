#pragma checksum "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\CoeporateBulkUpload\AuthorizeBulkCorporate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "88d3539a43a2ee3f16485af4a065bc93461699c8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CoeporateBulkUpload_AuthorizeBulkCorporate), @"mvc.1.0.view", @"/Views/CoeporateBulkUpload/AuthorizeBulkCorporate.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88d3539a43a2ee3f16485af4a065bc93461699c8", @"/Views/CoeporateBulkUpload/AuthorizeBulkCorporate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e7e6c2b2e2093347ee78387d906f49a77b633a7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_CoeporateBulkUpload_AuthorizeBulkCorporate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CorporateBatchDetailsPending>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\CoeporateBulkUpload\AuthorizeBulkCorporate.cshtml"
  
    ViewData["Title"] = "AuthorizeCorporate";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container-fluid\">\r\n\r\n    <!-- Page Heading -->\r\n    <h1 class=\"h3 mb-2 text-gray-800\">Authorize Corporate Details</h1>\r\n\r\n    <p><label style=\"color:red\">");
#nullable restore
#line 10 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\CoeporateBulkUpload\AuthorizeBulkCorporate.cshtml"
                           Write(Html.TempData["authMessage"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label></p>

    <div class=""card shadow mb-4"">
        <div class=""card-header py-3"">
            <h6 class=""m-0 font-weight-bold text-primary"">Pending Bulk Corporate</h6>
        </div>
        <div class=""card-body"">
            <div class=""table-responsive"">

                <table class=""table table-bordered"" id=""dataTable"" width=""100%"" style=""font-family:Calibri;font-size:14px"" cellspacing=""0"">
                    <thead>
                        <tr style=""background-color: lightgrey; color: black"">
                            <th></th>
                            <th></th>
                            <th>Corporate List</th>
                            <th>Created By</th>
                            <th>Date Initiated</th>

                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 31 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\CoeporateBulkUpload\AuthorizeBulkCorporate.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td style=\"width:120px\">\r\n                                    ");
#nullable restore
#line 35 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\CoeporateBulkUpload\AuthorizeBulkCorporate.cshtml"
                               Write(Html.ActionLink("Authorize", "Auth", new { id = item.ID }, new { @class = "auth" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                </td>\r\n                                <td style=\"width: 120px\">\r\n                                    ");
#nullable restore
#line 39 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\CoeporateBulkUpload\AuthorizeBulkCorporate.cshtml"
                               Write(Html.ActionLink("View Corporate", "ViewUploadedExcel", new { id = item.ID }, new { @class = "view" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                </td>\r\n\r\n\r\n                                <td>\r\n                                    ");
#nullable restore
#line 45 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\CoeporateBulkUpload\AuthorizeBulkCorporate.cshtml"
                               Write(Html.DisplayFor(modelItem => item.corporatebulk));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 48 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\CoeporateBulkUpload\AuthorizeBulkCorporate.cshtml"
                               Write(Html.DisplayFor(modelItem => item.CREATEDBYNAME));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 51 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\CoeporateBulkUpload\AuthorizeBulkCorporate.cshtml"
                               Write(Html.DisplayFor(modelItem => item.DATECREATED));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n\r\n                            </tr>\r\n");
#nullable restore
#line 55 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\CoeporateBulkUpload\AuthorizeBulkCorporate.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n<div id=\"myModal\"></div>\r\n<div id=\"suppDocModal\"></div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
			$(""a.auth"").on('click', function () {
				$.ajax({
					url: this.href,
					type: 'Get',
					cache: false,
					success: function (result) {
						$('#myModal').html(result).find('.modal').modal({
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
                    cache: false,
                    success: function (result) {
                        $('#suppDocModal').html(result).find('.modal').modal({
                            show: true
                        });
                    }
                });
                return false;
            });
    </script>
");
            }
            );
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CorporateBatchDetailsPending>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
