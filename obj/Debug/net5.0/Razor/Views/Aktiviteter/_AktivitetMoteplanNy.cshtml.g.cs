#pragma checksum "C:\Visual Stuido 17\KipWeb5\Views\Aktiviteter\_AktivitetMoteplanNy.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "caa163fc645485fd1e6f1e9145939145c3fb08c9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Aktiviteter__AktivitetMoteplanNy), @"mvc.1.0.view", @"/Views/Aktiviteter/_AktivitetMoteplanNy.cshtml")]
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
#line 1 "C:\Visual Stuido 17\KipWeb5\Views\Aktiviteter\_AktivitetMoteplanNy.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"caa163fc645485fd1e6f1e9145939145c3fb08c9", @"/Views/Aktiviteter/_AktivitetMoteplanNy.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec4a0d041100f1c7f5b87fd2c1f80209d75b00ee", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Aktiviteter__AktivitetMoteplanNy : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<KipWeb5.Models.Aktiviteter.AktiviteterModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/save-filled.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/save-filled-close-window.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("tittel"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control k-textbox"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("beskrivelse"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height: 150px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/button-add.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString(" width: 24px; height: 24px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/trash-2.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Lagre", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("moteplanForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("return false;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("mt-0"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral(@"
<script>

    function filterAnsvarlig() {
        return { ressursType: ""0,1,99"" }
    }

    function filterSted() {
        return {soknNr: """", typeRom: ""Aktivitet""}
    }

    function changeDate() {
        currday = this.value();

        var datepicker = $(""#Moteplan_StartDato"").data(""kendoDatePicker"");
        datepicker.value(currday);
    }

    function onStarttimeChange(e) {
        var startTime = this.value();
        endPicker = $(""#Moteplan_SluttTid"").data(""kendoTimePicker"");

        if (startTime) {
            startTime = new Date(startTime);

            endPicker.max(startTime);

            startTime.setMinutes(startTime.getMinutes() + this.options.interval);

            endPicker.min(startTime);
            endPicker.value(startTime);
        }
    }
</script>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "caa163fc645485fd1e6f1e9145939145c3fb08c99697", async() => {
                WriteLiteral("\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "caa163fc645485fd1e6f1e9145939145c3fb08c99963", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
#nullable restore
#line 43 "C:\Visual Stuido 17\KipWeb5\Views\Aktiviteter\_AktivitetMoteplanNy.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Moteplan.AktiviteterGuid);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "caa163fc645485fd1e6f1e9145939145c3fb08c911785", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
#nullable restore
#line 44 "C:\Visual Stuido 17\KipWeb5\Views\Aktiviteter\_AktivitetMoteplanNy.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Moteplan.RessursGuidListe);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"

    <div class=""row"">

        <div class=""col-10"" style=""display: flex; flex-direction: row;"">

            <div>
                <button type=""button"" class=""command"" onclick=""lagreMoteplan(false)"" style=""width: 210px; margin-right: 7px;"">
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "caa163fc645485fd1e6f1e9145939145c3fb08c913888", async() => {
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
                WriteLiteral("\r\n                    ");
#nullable restore
#line 53 "C:\Visual Stuido 17\KipWeb5\Views\Aktiviteter\_AktivitetMoteplanNy.cshtml"
               Write(Localizer["Opprett og fortsett"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </button>\r\n            </div>\r\n\r\n            <div>\r\n                <button type=\"button\" class=\"command\" onclick=\"lagreMoteplan(true)\" style=\"width: 200px; margin-right: 7px;\">\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "caa163fc645485fd1e6f1e9145939145c3fb08c915479", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
#nullable restore
#line 60 "C:\Visual Stuido 17\KipWeb5\Views\Aktiviteter\_AktivitetMoteplanNy.cshtml"
               Write(Localizer["Opprett og lukk"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </button>\r\n            </div>\r\n\r\n        </div>\r\n\r\n    </div>\r\n\r\n    <div class=\"row\" style=\"min-height: 200px;\">\r\n\r\n        <div class=\"col-6\">\r\n            <div class=\"row\">\r\n                <div class=\"col-6\">\r\n                    ");
#nullable restore
#line 73 "C:\Visual Stuido 17\KipWeb5\Views\Aktiviteter\_AktivitetMoteplanNy.cshtml"
                Write(Html.Kendo().Calendar()
                        .Name("kalender")
                        .WeekNumber(true)
                        .ComponentType("modern")
                        .Events(e => e.Change("changeDate"))
                        .Messages(m => m.WeekColumnHeader("UN"))
                        );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n\r\n\r\n                <div class=\"col-6\">\r\n\r\n                    <div class=\"row\">\r\n                        <label style=\"margin-top: 5px;\" class=\"col-form-label\">");
#nullable restore
#line 86 "C:\Visual Stuido 17\KipWeb5\Views\Aktiviteter\_AktivitetMoteplanNy.cshtml"
                                                                          Write(Localizer["Sted"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                        <div class=\"col-12\">\r\n                            ");
#nullable restore
#line 88 "C:\Visual Stuido 17\KipWeb5\Views\Aktiviteter\_AktivitetMoteplanNy.cshtml"
                        Write(Html.Kendo().DropDownList()
                                .Name("Moteplan.Møtested")
                                .HtmlAttributes(new { style = "width:100%;" })
                                .DataTextField("Navn")
                                .DataValueField("RessursGuid")
                                .OptionLabel(Localizer["Velg møtested"].Value)
                                .OptionLabelTemplate("<span style='color: gray'><i>" + Localizer["Velg møtested"].Value + "</i></span>")
                                .Height(310)
                                .DataSource(source => source
                                .Ajax()
                                .Read(read => read.Action("getSeremonisteder", "Ressurs").Data("filterSted"))
                                )
                                );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n\r\n                    <div class=\"row\">\r\n                        <label class=\"col-form-label\">");
#nullable restore
#line 105 "C:\Visual Stuido 17\KipWeb5\Views\Aktiviteter\_AktivitetMoteplanNy.cshtml"
                                                 Write(Localizer["Ansvarlig"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                        <div Class=\"col-12\">\r\n                            ");
#nullable restore
#line 107 "C:\Visual Stuido 17\KipWeb5\Views\Aktiviteter\_AktivitetMoteplanNy.cshtml"
                        Write(Html.Kendo().DropDownList()
                                .Name("Moteplan.Ansvarlig")
                                .HtmlAttributes(new { style = "width:100%;" })
                                .DataTextField("Navn")
                                .DataValueField("RessursGuid")
                                .OptionLabel(Localizer["Ansvarlig person"].Value)
                                .OptionLabelTemplate("<span style='color: gray'><i>" + Localizer["Ansvarlig person"].Value + "</i></span>")
                                .Height(310)
                                .DataSource(source => source
                                    .Ajax()
                                    .Read(read => read.Action("getRessursListeMulti", "Ressurs").Data("filterAnsvarlig"))
                                    )
                                );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n\r\n                    <div class=\"row\">\r\n                        <label class=\"col-form-label\">");
#nullable restore
#line 124 "C:\Visual Stuido 17\KipWeb5\Views\Aktiviteter\_AktivitetMoteplanNy.cshtml"
                                                 Write(Localizer["Tidspunkt"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                        <div class=\"col-12\" style=\"margin-top: 10px;\">\r\n                            ");
#nullable restore
#line 126 "C:\Visual Stuido 17\KipWeb5\Views\Aktiviteter\_AktivitetMoteplanNy.cshtml"
                        Write(Html.Kendo().DatePicker()
                                .Name("Moteplan.StartDato")
                                .HtmlAttributes(new { style = "width: 120px;" })
                                );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </div>\r\n                        <div class=\"col-12\" style=\"display: flex; flex-direction: row; margin-top: 10px;\">\r\n                            ");
#nullable restore
#line 132 "C:\Visual Stuido 17\KipWeb5\Views\Aktiviteter\_AktivitetMoteplanNy.cshtml"
                        Write(Html.Kendo().TimePicker()
                                .Name("Moteplan.StartTid")
                                .Events(e => e.Change("onStarttimeChange"))
                                .HtmlAttributes(new { style = "width: 120px;" })
                                );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            ");
#nullable restore
#line 137 "C:\Visual Stuido 17\KipWeb5\Views\Aktiviteter\_AktivitetMoteplanNy.cshtml"
                        Write(Html.Kendo().TimePicker()
                                .Name("Moteplan.SluttTid")
                                .HtmlAttributes(new { style = "width: 120px; margin-left: 10px;" })
                                );

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                        </div>
                    </div>

                </div>

            </div>

            <div class=""row"">
                <div class=""col-12"">
                    <label class=""col-form-label"">Tittel</label>
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "caa163fc645485fd1e6f1e9145939145c3fb08c923335", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 151 "C:\Visual Stuido 17\KipWeb5\Views\Aktiviteter\_AktivitetMoteplanNy.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Moteplan.Emne);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    <label class=\"col-form-label\">Merknad</label>\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("textarea", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "caa163fc645485fd1e6f1e9145939145c3fb08c925088", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper);
#nullable restore
#line 153 "C:\Visual Stuido 17\KipWeb5\Views\Aktiviteter\_AktivitetMoteplanNy.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Moteplan.Tekst);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n\r\n            <div class=\"row\">\r\n                <div class=\"col-12\">\r\n                    <label class=\"col-form-label\">Etikett</label>\r\n                    ");
#nullable restore
#line 160 "C:\Visual Stuido 17\KipWeb5\Views\Aktiviteter\_AktivitetMoteplanNy.cshtml"
                Write(Html.Kendo().DropDownList()
                        .Name("Moteplan.Etikett")
                        .HtmlAttributes(new { style = "width:100%;" })
                        .DataTextField("Navn")
                        .DataValueField("Navn")
                        .Height(310)
                        .DataSource(source => source
                            .Ajax()
                        .Read(read => read.Action("GetEtikettListe", "Kalender"))
                            )
                        );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"col-6\">\r\n            <div class=\"row\">\r\n                <div class=\"d-flex\">\r\n                    <h4 class=\"me-auto align-self-end unselectable\">");
#nullable restore
#line 179 "C:\Visual Stuido 17\KipWeb5\Views\Aktiviteter\_AktivitetMoteplanNy.cshtml"
                                                               Write(Localizer["Øvrige ressurser"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</h4>

                    <div class=""col-lg-6 text-right"">
                        <div class=""align-items-end"">
                            <button class=""commandSmal"" type=""button"" onclick=""showDialogRessurs('Deltakere')"" style=""width: 100px;"">
                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "caa163fc645485fd1e6f1e9145939145c3fb08c928665", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                ");
#nullable restore
#line 185 "C:\Visual Stuido 17\KipWeb5\Views\Aktiviteter\_AktivitetMoteplanNy.cshtml"
                           Write(Localizer["Legg til"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </button>\r\n                            <button class=\"commandSmal\" type=\"button\" style=\"width: 100px;\">\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "caa163fc645485fd1e6f1e9145939145c3fb08c930299", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                ");
#nullable restore
#line 189 "C:\Visual Stuido 17\KipWeb5\Views\Aktiviteter\_AktivitetMoteplanNy.cshtml"
                           Write(Localizer["Slett"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </button>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n\r\n\r\n            ");
#nullable restore
#line 197 "C:\Visual Stuido 17\KipWeb5\Views\Aktiviteter\_AktivitetMoteplanNy.cshtml"
        Write(Html.Kendo().Grid<KipWeb5.Models.RessursItem>()
                .Name("Deltakere")
                .Columns(columns =>
                {
                    columns.Bound(p => p.RessursGuid).Visible(false);
                    columns.Bound(p => p.Navn).Title(Localizer["Navn"].Value);
                })
                .Sortable()
                .Navigatable()
                .Height(460)
                .Scrollable()
                .Selectable(s => s
                    .Mode(GridSelectionMode.Multiple)
                    .Type(GridSelectionType.Row))

                );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_12.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_12);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_13);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<KipWeb5.Models.Aktiviteter.AktiviteterModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
