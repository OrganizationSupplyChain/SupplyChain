#pragma checksum "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Audit\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8afa4f6be64f1274620088676ea6bae2ac2a8f53"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Audit_Index), @"mvc.1.0.view", @"/Views/Audit/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8afa4f6be64f1274620088676ea6bae2ac2a8f53", @"/Views/Audit/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e7e6c2b2e2093347ee78387d906f49a77b633a7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Audit_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AuditDetails>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Audit\Index.cshtml"
  
    ViewData["Title"] = "Application Audit";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container-fluid\">\r\n    <div class=\"row\">\r\n        <div class=\"col-12 d-flex justify-content-between\">\r\n            <h3 class=\"page-title\">Audit Log</h3>\r\n            <p>");
#nullable restore
#line 10 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Audit\Index.cshtml"
          Write(DateTime.UtcNow.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>

        </div>
    </div>

    <div class=""row mt-4"">
        <div class=""col-12 d-flex justify-content-between align-items-center"">
            <div class=""search-group"">
                <input type=""text"" style=""width: 300px;"" id=""txtSearch"" placeholder=""search"" class=""form-control pl-5""
                       aria-label=""Text input with checkbox"">
                <i class=""fa fa-search""></i>
            </div>

");
            WriteLiteral(@"        </div>
    </div>

    <div class=""row my-5"">
        <div class=""col-12"">
            <div class=""card my-card"">
                <div class=""card-body px-0"">

                    <div class=""notif-wrapper p-4 notif-card "" style=""height: 55vh;"">

                        <table id=""audit"" class=""table"" style=""width:100%"">
                            <thead style=""text-align:left"">
                                <tr>
                                    <th>S/N</th>
                                    <th>Enterprise Username</th>
                                    <th>Action Performed</th>
                                    <th>Time Stamp</th>
                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 46 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Audit\Index.cshtml"
                                   int i = 1; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Audit\Index.cshtml"
                                 if (Model == null)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td colspan=\"4\">No Record Found</td>\r\n                                    </tr>\r\n");
#nullable restore
#line 52 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Audit\Index.cshtml"
                                }
                                else
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Audit\Index.cshtml"
                                     foreach (var item in Model)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <td>\r\n                                                <label> ");
#nullable restore
#line 59 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Audit\Index.cshtml"
                                                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </label>\r\n");
#nullable restore
#line 60 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Audit\Index.cshtml"
                                                   i++; 

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 63 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Audit\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.USERNAME));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 66 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Audit\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.ACTIVITIES));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 69 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Audit\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.DATECREATED));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n\r\n                                        </tr>\r\n");
#nullable restore
#line 73 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Audit\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 73 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Audit\Index.cshtml"
                                     
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </tbody>\r\n                        </table>\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>

        $(document).ready(function () {
            $('#audit').DataTable({
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

        $('#txtSearch').on('keyup', function () {

            var searchTxt = $(""#txtSearch"").val();
            $('#audit').DataTable().search(searchTxt).draw();
        });
       
    </script>
");
            }
            );
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AuditDetails>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591