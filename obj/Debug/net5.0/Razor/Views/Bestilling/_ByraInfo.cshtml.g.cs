#pragma checksum "C:\Visual Stuido 17\KipWeb5\Views\Bestilling\_ByraInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3349f943370a298c73df65e587c7c42d6ee7811a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Bestilling__ByraInfo), @"mvc.1.0.view", @"/Views/Bestilling/_ByraInfo.cshtml")]
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
#line 1 "C:\Visual Stuido 17\KipWeb5\Views\_ViewImports.cshtml"
using KipWeb5;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Visual Stuido 17\KipWeb5\Views\_ViewImports.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Visual Stuido 17\KipWeb5\Views\Bestilling\_ByraInfo.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3349f943370a298c73df65e587c7c42d6ee7811a", @"/Views/Bestilling/_ByraInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec4a0d041100f1c7f5b87fd2c1f80209d75b00ee", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Bestilling__ByraInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<KipWeb5.Models.Bestilling.BestillingModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/eye.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:24px; height: 24px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/ItemStatus3.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control k-textbox"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 100px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<script>\r\n\r\n\r\n</script>\r\n\r\n<div id=\"bestillingInfoForm\">\r\n");
#nullable restore
#line 12 "C:\Visual Stuido 17\KipWeb5\Views\Bestilling\_ByraInfo.cshtml"
     if(Model != null) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-12 padding-0\" style=\"margin-top: 10px;\">\r\n            <div class=\"row\">\r\n                <div class=\"d-flex\">\r\n                    <h4 class=\"me-auto align-self-end unselectable\">");
#nullable restore
#line 16 "C:\Visual Stuido 17\KipWeb5\Views\Bestilling\_ByraInfo.cshtml"
                                                               Write(Localizer["Seremonitidspunkt"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n\r\n                    <div class=\"align-items-end\">\r\n                        <button class=\"commandSmal\" type=\"button\" onclick=\"setStatusLest()\" style=\"width: 150px;\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3349f943370a298c73df65e587c7c42d6ee7811a6235", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
#nullable restore
#line 21 "C:\Visual Stuido 17\KipWeb5\Views\Bestilling\_ByraInfo.cshtml"
                       Write(Localizer["Set som Lest"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </button>\r\n                        <button class=\"commandSmal\" type=\"button\" onclick=\"setStatusOk()\" style=\"width: 150px;\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3349f943370a298c73df65e587c7c42d6ee7811a7801", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
#nullable restore
#line 25 "C:\Visual Stuido 17\KipWeb5\Views\Bestilling\_ByraInfo.cshtml"
                       Write(Localizer["Bekreft ok"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </button>
                    </div>
 
                </div>
            </div>
            <div class=""panel panel-default"" style=""padding: 10px; background-color: transparent;"">

                <div class=""row"">
                    <div class=""col-5"">
                        <label class=""col-form-label"">");
#nullable restore
#line 35 "C:\Visual Stuido 17\KipWeb5\Views\Bestilling\_ByraInfo.cshtml"
                                                 Write(Localizer["Sokn"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n\r\n                        ");
#nullable restore
#line 37 "C:\Visual Stuido 17\KipWeb5\Views\Bestilling\_ByraInfo.cshtml"
                    Write(Html.Kendo().DropDownList()
                            .Name("SermSokn")
                            .DataTextField("SoknNavn")
                            .DataValueField("SoknId")
                            .Value(Model.Bestilling.SermSokn)
                            .OptionLabel(Localizer["Sokn ikke bestemt"].Value)
                            .OptionLabelTemplate("<span style='color: gray'><i>" + Localizer["Sokn ikke bestemt"].Value + "</i></span>")
                            .HtmlAttributes(new { style = "width: 150px; margin-right: 20px;" })
                            .DataSource(dataSource => dataSource
                                .Ajax()
                                .Read(read => read.Action("GetFellesraadSoknListe", "Sokn"))
                                )
                            );

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </div>
                </div>

                <table class=""table table-borderless"" style=""table-layout: fixed; margin-left: 0px; margin-top: 0px; border: 0px;"">
                    <tr>
                        <td style=""width: 48px; padding-top: 4px;"">
                            <label class=""col-form-label"">Seremoni</label>
                        </td>
                        <td style=""width: 110px;"">
                            ");
#nullable restore
#line 59 "C:\Visual Stuido 17\KipWeb5\Views\Bestilling\_ByraInfo.cshtml"
                        Write(Html.Kendo().DropDownList()
                                .Name("sermStedGuid")
                                .DataTextField("Navn")
                                .DataValueField("RessursGuid")
                                .Value(Model.Bestilling.sermStedGuid)
                                .OptionLabel(Localizer["Seremonisted ikke bestemt"].Value)
                                .OptionLabelTemplate("<span style='color: gray'><i>" + Localizer["Seremonisted ikke bestemt"].Value + "</i></span>")
                                .HtmlAttributes(new { @class = "nodvendigFelt"})
                                .DataSource(dataSource => dataSource
                                    .Ajax()
                                    .Read(read => read.Action("getSeremonisteder", "Ressurs").Data("filterKirke"))
                                    )
                                );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td style=\"width: 58px; padding-top: 8px;\">\r\n                             ");
#nullable restore
#line 74 "C:\Visual Stuido 17\KipWeb5\Views\Bestilling\_ByraInfo.cshtml"
                         Write(Html.Kendo().DatePicker().Name("SermDato").Value(Model.Bestilling.SermDato).HtmlAttributes(new { style = "width: 120px; readonly"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td style=\"width: 58px; padding-top: 8px;\">\r\n                             ");
#nullable restore
#line 77 "C:\Visual Stuido 17\KipWeb5\Views\Bestilling\_ByraInfo.cshtml"
                         Write(Html.Kendo().TimePicker().Name("SermTid").Value(Model.Bestilling.SermTid).HtmlAttributes(new { style = "width: 90px; margin-left: 10px; padding-left:0px" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td style=\"width: 58px; padding-top: 8px;\">\r\n                            ");
#nullable restore
#line 80 "C:\Visual Stuido 17\KipWeb5\Views\Bestilling\_ByraInfo.cshtml"
                        Write(Html.Kendo().TimePicker().Name("SermSluttTid").Value(Model.Bestilling.SermSluttTid).HtmlAttributes(new { style = "width: 90px; margin-left: 10px; padding-left:0px" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </td>
                    </tr>

                    <tr>
                        <td style=""padding-top: 4px;"">
                            <label class=""col-form-label"">Gravferd</label>
                        </td>
                        <td>
                            ");
#nullable restore
#line 89 "C:\Visual Stuido 17\KipWeb5\Views\Bestilling\_ByraInfo.cshtml"
                        Write(Html.Kendo().DropDownList()
                                .Name("gravStedGuid")
                                .DataTextField("Navn")
                                .DataValueField("RessursGuid")
                                .Value(Model.Bestilling.gravStedGuid)
                                .TemplateId("liste-template")
                                .OptionLabel(Localizer["Gravsted ikke bestemt"].Value)
                                .OptionLabelTemplate("<span style='color: gray'><i>" + Localizer["Gravsted ikke bestemt"].Value + "</i></span>")
                                .HtmlAttributes(new { @class = "nodvendigFelt"})
                                .DataSource(dataSource => dataSource
                                    .Ajax()
                                    .Read(read => read.Action("getGravsteder", "Ressurs"))
                                    )
                                );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3349f943370a298c73df65e587c7c42d6ee7811a15489", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 105 "C:\Visual Stuido 17\KipWeb5\Views\Bestilling\_ByraInfo.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Bestilling.gravDato);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("readonly", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 108 "C:\Visual Stuido 17\KipWeb5\Views\Bestilling\_ByraInfo.cshtml"
                        Write(Html.Kendo().TimePicker().Name("gravStartTid").Value(Model.Bestilling.gravStartTid).HtmlAttributes(new { style = "width: 90px; margin-left: 10px; padding-left:0px" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 111 "C:\Visual Stuido 17\KipWeb5\Views\Bestilling\_ByraInfo.cshtml"
                        Write(Html.Kendo().TimePicker().Name("gravSluttTid").Value(Model.Bestilling.gravSluttTid).HtmlAttributes(new { style = "width: 90px; margin-left: 10px; padding-left:0px" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n                </table>\r\n\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 118 "C:\Visual Stuido 17\KipWeb5\Views\Bestilling\_ByraInfo.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>

<script>

    $(document).ready(function () {        
        $(""#SermSokn"").data(""kendoDropDownList"").readonly();
        
        $(""#sermStedGuid"").data(""kendoDropDownList"").readonly();
        $(""#SermDato"").data(""kendoDatePicker"").readonly();
        $(""#SermTid"").data(""kendoTimePicker"").readonly();
        $(""#SermSluttTid"").data(""kendoTimePicker"").readonly();

        $(""#gravStedGuid"").data(""kendoDropDownList"").readonly();
        $(""#gravStartTid"").data(""kendoTimePicker"").readonly();
        $(""#gravSluttTid"").data(""kendoTimePicker"").readonly();        
    });

</script>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IViewLocalizer Localizer { get; private set; } = default!;
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<KipWeb5.Models.Bestilling.BestillingModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
