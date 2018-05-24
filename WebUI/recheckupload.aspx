<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recheckupload.aspx.cs" Inherits="WebUI.recheckupload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport"
          content="initial-scale=1.0, user-scalable=no, width=device-width" />
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <title>无标题文档</title>
    <link href="assets/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="assets/js/jquery.js"></script>
    <link rel="stylesheet" href="assets/css/zTreeStyle/zTreeStyle.css" type="text/css" />
    <script type="text/javascript" src="assets/js/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="assets/js/jquery.ztree.core-3.5.js"></script>
    <script type="text/javascript" src="data/data.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    
    <div class="place">
        <span>位置：</span>
        <ul class="placeul">
            <li><a href="#">首页</a></li>
            <li><a href="#">上传资料</a></li>
            <li><a href="#">复查问题</a></li>
        </ul>
    </div>

    <div class="mainindex">
        <div>
            <ul class="seachform taul">
                <li><label>拍照</label><asp:FileUpload ID="FupPhoto" runat="server" /></li>
                
                <li><label>&nbsp;</label><asp:Button ID="BtnConfirm" runat="server" Text="确定" CssClass="scbtn" OnClick="BtnConfirm_Click"  /></li>
            </ul>
            <div class="xline" align="center"></div>
        </div>
    </div>


    </form>
</body>
</html>
		