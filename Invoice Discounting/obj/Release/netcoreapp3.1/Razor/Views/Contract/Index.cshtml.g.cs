#pragma checksum "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "963954535cee726979c959ed752d2d64c0d9e11c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contract_Index), @"mvc.1.0.view", @"/Views/Contract/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"963954535cee726979c959ed752d2d64c0d9e11c", @"/Views/Contract/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e7e6c2b2e2093347ee78387d906f49a77b633a7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Contract_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<VendorContractListModel>>
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
#line 2 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\Index.cshtml"
  
    ViewData["Title"] = "Corporate Contract";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container-fluid\">\r\n    <div class=\"row\">\r\n        <div class=\"col-12 d-flex justify-content-between\">\r\n            <h3 class=\"page-title\">Contracts</h3>\r\n            <p>");
#nullable restore
#line 10 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\Index.cshtml"
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
                <input type=""text"" style=""width: 300px;"" placeholder=""search"" id=""txtSearch"" class=""form-control pl-5""
                       aria-label=""Text input with checkbox"">
                <i class=""fa fa-search""></i>
            </div>

            <div>
                <button type=""button"" class=""btn btn-outline-primary blue-outline-btn"" id=""btnCreateNew"">
                    Create New ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "963954535cee726979c959ed752d2d64c0d9e11c5995", async() => {
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

    <div class=""row my-5"">
        <div class=""col-12"">
            <div class=""card my-card"">
                <div class=""card-body px-0"">
                    <div class=""header px-4 pb-3 d-flex justify-content-between align-items-center"">
                        <h5 class=""card-title mb-0"">Contracts List</h5>

                    </div>

                    <div class=""notif-wrapper p-4 notif-card "" style=""height: 55vh;"">
                        <table id=""contractTable"" class=""table"" style=""width:100%"">
                            <thead style=""text-align:left"">
                                <tr>
                                    <th>S/N</th>
                                    <th>Description</th>
                                    <th>Contract No</th>
                                    <th>Payment Tenor</th>
                                    <th>Contract Amount</th>
                                    <th>PO Number</th>
    ");
            WriteLiteral(@"                                <th>Vendor</th>
                                    <th>Date Created</th>
                                    <th>Status</th>
                                    <th>Action</th>
                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 62 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\Index.cshtml"
                                   int i = 1; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 63 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\Index.cshtml"
                                 if (Model == null)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td colspan=\"9\">No Record Found</td>\r\n                                    </tr>\r\n");
#nullable restore
#line 68 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\Index.cshtml"
                                }
                                else
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 71 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\Index.cshtml"
                                     foreach (var item in Model)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    <label> ");
#nullable restore
#line 75 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\Index.cshtml"
                                       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </label>\r\n");
#nullable restore
#line 77 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\Index.cshtml"
                                       i++; 

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 80 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.DESCRIPTION));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 83 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\Index.cshtml"
                               Write(Html.ActionLink(item.CONTRACTNUMBER, "GetVendorResponseList", "ContractResponse", new { contractId = item.ID }, new { @class = "link blue" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 86 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.PAYMENTTENOR));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 89 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.CONTRACTAMOUNT));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 92 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.PONUMBER));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 95 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.AWARDVENDORNAME));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 98 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.CREATEDDATE));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n\r\n                                <td>\r\n");
#nullable restore
#line 102 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\Index.cshtml"
                                     if (item.CONTRACTSTATUS == "Awarded")
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <div class=\"status alert alert-success mb-0 py-1\" role=\"alert\"  style=\"width:120px\">\r\n                                            <label>Awarded</label>\r\n                                        </div>\r\n");
#nullable restore
#line 107 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\Index.cshtml"
                                    }
                                    else if (item.CONTRACTSTATUS == "In Progress")
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <div class=\"status alert alert-primary mb-0 py-1\" role=\"alert\"  style=\"width:120px\">\r\n                                            <label>In Progress</label>\r\n                                        </div>\r\n");
#nullable restore
#line 113 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    \r\n                                </td>\r\n                                <td>\r\n");
#nullable restore
#line 117 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\Index.cshtml"
                                     if (item.CONTRACTSTATUS != "Awarded")
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <div class=\"d-flex justify-content-around\">\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 5816, "\"", 5886, 1);
#nullable restore
#line 120 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\Index.cshtml"
WriteAttributeValue("", 5823, Url.Action("ModifyContract", "Contract", new { id = item.ID }), 5823, 63, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"link blue\">\r\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "963954535cee726979c959ed752d2d64c0d9e11c16593", async() => {
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
            WriteLiteral("\r\n                                            </a>\r\n                                        </div>\r\n");
#nullable restore
#line 124 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </td>\r\n                            </tr>\r\n");
#nullable restore
#line 127 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 127 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\Index.cshtml"
                                     
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n\r\n<div id=\"cmodal\"></div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>

        $(document).ready(function () {
            var vendorTable = $('#contractTable').DataTable({
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
            $('#contractTable').DataTable().search(searchTxt).draw();
        });
           
        
        $(""#b");
                WriteLiteral("tnCreateNew\").on(\'click\', function () {\r\n           window.location.href = \'");
#nullable restore
#line 177 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\Index.cshtml"
                              Write(Url.Action("AddContract", "Contract"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n        });\r\n\r\n\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<VendorContractListModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
