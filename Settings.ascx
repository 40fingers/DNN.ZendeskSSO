<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="FortyFingers.ZendeskSso.Settings" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<div class="dnnForm" id="zendeskSsoForm">
    <fieldset>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ControlName="NameTextBox" ResourceKey="plZendeskSharedKey" />
            <asp:TextBox runat="server" ID="txtZendeskSharedKey" CssClass="dnnFormRequired" />
        </div>
        <div class="dnnFormItem">
            <dnn:Label runat="server" ControlName="NameTextBox" ResourceKey="plZendeskSubDomain" />
            <asp:TextBox runat="server" ID="txtZendeskSubDomain" CssClass="dnnFormRequired" />
        </div>
    </fieldset>
</div>
            