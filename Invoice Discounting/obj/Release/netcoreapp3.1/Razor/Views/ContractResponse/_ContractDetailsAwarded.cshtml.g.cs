#pragma checksum "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\_ContractDetailsAwarded.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8ca32fd537d65a2deeefd94a6e1303a3ddfcf6d0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ContractResponse__ContractDetailsAwarded), @"mvc.1.0.view", @"/Views/ContractResponse/_ContractDetailsAwarded.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ca32fd537d65a2deeefd94a6e1303a3ddfcf6d0", @"/Views/ContractResponse/_ContractDetailsAwarded.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e7e6c2b2e2093347ee78387d906f49a77b633a7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_ContractResponse__ContractDetailsAwarded : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VendorContractListModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/images/close-icon.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ContractResponse", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ContractDetailsRedirect", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("frmcontractresponse"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("autocomplete", new global::Microsoft.AspNetCore.Html.HtmlString("off"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8ca32fd537d65a2deeefd94a6e1303a3ddfcf6d05963", async() => {
                WriteLiteral("\r\n\r\n");
                WriteLiteral(@"    <div class=""modal right fade show my-modal"" id=""right_modal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""right_modal"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header px-5"">
                    <h5 class=""modal-title"">Contract Number - ");
#nullable restore
#line 16 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\_ContractDetailsAwarded.cshtml"
                                                         Write(Model.CONTRACTNUMBER);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h5>\r\n                    <button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-label=\"Close\">\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8ca32fd537d65a2deeefd94a6e1303a3ddfcf6d07103", async() => {
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
                WriteLiteral(@"
                    </button>
                </div>
                <div class=""modal-body py-3 px-5"">
                    <div class=""contract-item"">
                        <h4>
                            Name of Item:
                        </h4>
                        ");
#nullable restore
#line 26 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\_ContractDetailsAwarded.cshtml"
                   Write(Html.HiddenFor(model => model.ID));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        ");
#nullable restore
#line 27 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\_ContractDetailsAwarded.cshtml"
                   Write(Html.HiddenFor(model => model.CONTRACTSTATUS));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        <p>");
#nullable restore
#line 28 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\_ContractDetailsAwarded.cshtml"
                      Write(Model.CONTRACTNAME);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                    </div>\r\n                    <div class=\"contract-item\">\r\n                        <h4>\r\n                            Quality:\r\n                        </h4>\r\n                        <p>");
#nullable restore
#line 34 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\_ContractDetailsAwarded.cshtml"
                      Write(Model.QUALITYSPECIFICATION);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                    </div>\r\n                    <div class=\"contract-item\">\r\n                        <h4>\r\n                            Contract Amount:\r\n                        </h4>\r\n                        <p>");
#nullable restore
#line 40 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\_ContractDetailsAwarded.cshtml"
                      Write(Model.CONTRACTAMOUNT);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                    </div>\r\n                    <div class=\"contract-item\">\r\n                        <h4>\r\n                            Description:\r\n                        </h4>\r\n                        <p>\r\n                            ");
#nullable restore
#line 47 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\_ContractDetailsAwarded.cshtml"
                       Write(Model.DESCRIPTION);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </p>\r\n                    </div>\r\n                   <div class=\"contract-item\">\r\n                        <h4>\r\n                            Client\r\n                        </h4>\r\n                        <p>");
#nullable restore
#line 54 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\_ContractDetailsAwarded.cshtml"
                      Write(Model.CORPORATENAME);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                    </div>\r\n                    <div class=\"contract-item\">\r\n                        <h4>\r\n                            Other Information:\r\n                        </h4>\r\n                        <p>");
#nullable restore
#line 60 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\_ContractDetailsAwarded.cshtml"
                      Write(Model.OTHERINFORMATION);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                    </div>\r\n");
                WriteLiteral("                    <div class=\"contract-item\">\r\n                        <h4>\r\n                            Timeline for\r\n                            Fulfilment:\r\n                        </h4>\r\n                        <p>");
#nullable restore
#line 72 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\_ContractDetailsAwarded.cshtml"
                      Write(Model.TIMELINEDAYS);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                    </div>\r\n                    <div class=\"contract-item\">\r\n                        <h4>\r\n                            Payment Tenor:\r\n                        </h4>\r\n                        <p>");
#nullable restore
#line 78 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\_ContractDetailsAwarded.cshtml"
                      Write(Model.PAYMENTTENOR);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                    </div>\r\n                    <div class=\"contract-item\">\r\n                        <h4>\r\n                            Required\r\n                            Documents:\r\n                        </h4>\r\n                        <p>");
#nullable restore
#line 85 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\_ContractDetailsAwarded.cshtml"
                      Write(Model.REQUIREDDOCUMENTS);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                    </div>\r\n                    <div class=\"contract-item\">\r\n                        <h4>\r\n                            Contract Number:\r\n                        </h4>\r\n                        <p>");
#nullable restore
#line 91 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\_ContractDetailsAwarded.cshtml"
                      Write(Model.CONTRACTNUMBER);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                    </div>\r\n                    <div class=\"contract-item\">\r\n                        <h4>\r\n                            PO Number:\r\n                        </h4>\r\n                        <p>");
#nullable restore
#line 97 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\_ContractDetailsAwarded.cshtml"
                      Write(Model.PONUMBER);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                    </div>\r\n");
#nullable restore
#line 99 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\_ContractDetailsAwarded.cshtml"
                     if (Model.CONTRACTSTATUS == "Awarded")
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        <div class=""contract-item"">
                            <h4>
                                Status:
                            </h4>
                            <p class=""text-success"">Awarded</p>
                        </div>
");
#nullable restore
#line 107 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\_ContractDetailsAwarded.cshtml"
                    }
                    else if (Model.CONTRACTSTATUS == "Rejected")
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        <div class=""contract-item"">
                            <h4>
                                Status:
                            </h4>
                            <p class=""text-danger"">Rejected</p>
                        </div>
");
#nullable restore
#line 116 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\_ContractDetailsAwarded.cshtml"
                    }
                    else if (Model.CONTRACTSTATUS == "Completed")
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        <div class=""contract-item"">
                            <h4>
                                Status:
                            </h4>
                            <p class=""text-info"">Completed</p>
                        </div>
");
#nullable restore
#line 125 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\_ContractDetailsAwarded.cshtml"
                    }
                    else if (Model.CONTRACTSTATUS == "Pending")
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        <div class=""contract-item"">
                            <h4>
                                Status:
                            </h4>
                            <p class=""text-primary"">Pending Approval</p>
                        </div>
");
#nullable restore
#line 134 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\_ContractDetailsAwarded.cshtml"
                    }
                    else if (Model.CONTRACTSTATUS == "Declined")
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        <div class=""contract-item"">
                            <h4>
                                Status:
                            </h4>
                            <p class=""text-danger"">Declined</p>
                        </div>
");
#nullable restore
#line 143 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\_ContractDetailsAwarded.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n\r\n");
#nullable restore
#line 147 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\_ContractDetailsAwarded.cshtml"
                 if (Model.CONTRACTSTATUS == "Awarded")
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <div class=\"modal-footer modal-footer-fixed border-top-0\">\r\n                        <button type=\"submit\" class=\"btn btn-primary my-primary wid100\">Raise Invoice</button>\r\n                    </div>\r\n");
#nullable restore
#line 152 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\_ContractDetailsAwarded.cshtml"
                }
                else if (Model.CONTRACTSTATUS == "New")
                {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    <div class=""modal-footer modal-footer-fixed border-top-0 d-flex justify-content-center"" style=""column-gap: 30px;"">

                        <button type=""submit"" class=""btn btn-primary my-primary btn-sm"" style=""width: 128px;"">Apply</button>
                        <button type=""button"" data-dismiss=""modal"" id=""btndecline"" class=""btn btn-outline-primary orange-outline-btn btn-sm"" style=""width: 128px;"">Decline</button>
                            
                    </div>
");
#nullable restore
#line 161 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\_ContractDetailsAwarded.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </div>\r\n                </div>\r\n        </div>\r\n\r\n    <script>\r\n        $.ajaxPrefilter(function (options, originalOptions, jqXHR) {\r\n                jqXHR.setRequestHeader(\"__RequestVerificationToken\", \'");
#nullable restore
#line 168 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\_ContractDetailsAwarded.cshtml"
                                                                 Write(GetAntiXsrfRequestToken());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"');
        });

        $(""#btndecline"").on('click', function () {
           // $(""#myModal"").modal('hide');
            //$(""#cmodal"").modal('hide');
            $.ajax({
                url: '/ContractResponse/ContractResponseDecined',
                data: $('#frmcontractresponse').serialize(),
                type: 'POST',
                success: function (result) {

                    location.reload();
                    return true;
                }
            });
        });
    </script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
#nullable restore
#line 6 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\_ContractDetailsAwarded.cshtml"
               
        public string GetAntiXsrfRequestToken()
        {
            return Xsrf.GetAndStoreTokens(Context).RequestToken;
        }
    

#line default
#line hidden
#nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Antiforgery.IAntiforgery Xsrf { get; private set; } = default!;
        #nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<VendorContractListModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591