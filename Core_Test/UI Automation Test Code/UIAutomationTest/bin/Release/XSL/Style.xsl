<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet
version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="html" indent="yes" encoding="UTF-8" />

<xsl:template match="/">
<html>
  <head><title>Test Result</title>
<style type="text/css">

body,div,ul,li{
padding:0;
text-align:center;
}
body{
font:12px "Arial";
text-align:center;
}
a:link{
color:#00F;
text-decoration:none;
}
a:visited {
color: #00F;
text-decoration:none;
}
a:hover {
color: #c00;
text-decoration:underline;
}
ul{ list-style:none;}

#Tab1{
width:100%;
margin:0px;
padding:0px;
margin:0 auto;
}

#Tab2{
width:100%;
margin:0px;
padding:0px;
margin:0 auto;}

#Menubox {
width:100%;
background:url(.\\XSL\\200801081251340.gif);
height:28px;
line-height:28px;
position:fixed;

}
#Menubox ul{
margin:0px;
padding:0px;
}
#Menubox li{
float:left;
display:block;
cursor:pointer;
width:114px;
text-align:center;
color:#949694;
font-weight:bold;
}
#Menubox li.hover{
padding:0px;
background:#fff;
width:118px;
border-left:1px solid #A8C29F;
border-top:1px solid #A8C29F;
border-right:1px solid #A8C29F;
background:url(.\\XSL\\1.bmp);
color:orange;
font-weight:bold;
height:27px;
line-height:27px;
}
#Contentbox{
clear:both;
margin-top:35px;
border:1px solid #A8C29F;
border-top:none;
text-align:center;
padding-top:8px;
color:black
}

</style>
<script type="text/javascript">
<xsl:comment>
<![CDATA[

function yiru(t){   
	var ei = document.getElementById("big_image");
	ei.style.display = "block";
	ei.innerHTML = '<img src="' + t.src + '" width="800px" height="600px" />';
	ei.style.top  = document.body.scrollTop   +   ei.clientHeight/2   -   250; //document.body.scrollTop+window.event.clientY-10+"px";
	ei.style.left = (window.screen.width   -   ei.clientWidth)/2;//window.event.clientX - 900+"px";
}

function yichu(){
    var ei = document.getElementById("big_image");
    ei.innerHTML = "";
    ei.style.display = "none";
}

//display the selected component test result, it is invoked when click a <li> and a innertext in the <table> in "Summary". 
function setTab(CompID){
       
       var CompName = CompID.substring(3);	
       var arrLi = document.getElementsByTagName("li");	
	 var strDiv, strCompName
	 for(var i=0;i<arrLi.length;i++)
	 {				
		strDiv=arrLi[i].id.replace("li_","div_");
		strCompName = arrLi[i].id.substring(3);	
		var div=document.getElementById(strDiv);			
		arrLi[i].className=strCompName==CompName?"hover":"";
		div.style.display=strCompName==CompName?"block":"none";	
	}
	
	if(CompName != "Summary"){			
		changecolor("table_" + CompName);
	}
}


function changecolorSummary(){
	if (document.getElementById("table_Summary").rows.length>3){
		document.getElementById("table_Summary").rows[0].style.backgroundColor="lime";
		document.getElementById("table_Summary").rows[0].style.fontWeight="bold";
		document.getElementById("table_Summary").rows[1].style.backgroundColor="Red";
		document.getElementById("table_Summary").rows[1].style.color="white";
		document.getElementById("table_Summary").rows[1].style.fontWeight="bold";
		document.getElementById("table_Summary").rows[2].style.backgroundColor="royalblue";
		document.getElementById("table_Summary").rows[2].style.color="white";
		document.getElementById("table_Summary").rows[2].style.fontWeight="bold";
		}

}

//define the test result font color
function changecolor(tableID){
for(var i=1;i<document.getElementById(tableID).rows.length;i++){
	var ei = document.getElementById(tableID).rows[i].cells(5);
	if(ei.innerText == "FAILED")
		{ei.style.color = "red";}
	else if(ei.innerText == "BLOCKED")
		{ei.style.color = "blue";}
	else if(ei.innerText == "PASSED")
		{ei.style.color = "green";}
	}

}
/*
var ie=document.all;
var nn6=document.getElementById&&!document.all;
var isdrag=false;
var y,x;
var oDragObj;
function moveMouse(e) {
if (isdrag) {
oDragObj.style.top  =  (nn6 ? nTY + e.clientY - y : nTY + event.clientY - y)+"px";
oDragObj.style.left  =  (nn6 ? nTX + e.clientX - x : nTX + event.clientX - x)+"px";
return false;
}
}
function initDrag(e) {
var oDragHandle = nn6 ? e.target : event.srcElement;
var topElement = "HTML";
while (oDragHandle.tagName != topElement && oDragHandle.className != "dragAble") {
oDragHandle = nn6 ? oDragHandle.parentNode : oDragHandle.parentElement;
}
if (oDragHandle.className=="dragAble") {
isdrag = true;
oDragObj = oDragHandle;
nTY = parseInt(oDragObj.style.top+0);
y = nn6 ? e.clientY : event.clientY;
nTX = parseInt(oDragObj.style.left+0);
x = nn6 ? e.clientX : event.clientX;
document.onmousemove=moveMouse;
return false;
}
}
document.onmousedown=initDrag;
document.onmouseup=new Function("isdrag=false");
   
   */
]]>

</xsl:comment>
</script>
</head>
<body background=".\\XSL\\space.jpg" style="color:black;"  onload="changecolorSummary();"> 

<div id="big_image" style="position: absolute; left:0px; top:0px; display: none; border: 0px solid #f4f4f4;" class="dragAble" onmouseout="yichu();">
</div>

<div id="Tab1">
	<div id="Menubox" style="position: absolute; left:10px; top: 0px; top:expression(offsetParent.scrollTop); z-index: 1;">		
		<ul>
			<li id="li_Summary" onclick="setTab(this.id)" class="hover">Summary</li>
			<xsl:apply-templates select="TestResult//ComponentSummary//Field//Component_Name"/>
		</ul>
	</div>


<div id="Contentbox" >
<div id="div_Summary" style="font-size: 20px; text-align: center; vertical-align: Top;">
<font size="5"><b>Automation Test Summary</b></font>
<table width="100%" border="2" bordercolor="black" style="font-size:11px;color:black" cellspacing="1" FRAME="box">
<THEAD>
	<tr>
            <td style="text-align: center; vertical-align: center; width:35%">
               <table id="table_Summary" width="100%" border="2" bordercolor="black" style="font-size:12px;color:black" cellspacing="1" FRAME="box">
			<TBODY>
			<xsl:for-each select="TestResult/TestSummary/Field">
          		<tr>
			<td style="width:43%; "><xsl:value-of select="Argument" /></td>
			<td><xsl:value-of select="Value" /></td>
            	
          		</tr>
			</xsl:for-each>
 			</TBODY>
    		</table>
            </td>

<td style="text-align: center; vertical-align: center; width:20%; color:red">
<font size="3"><b><u></u></b></font>
<br>Something</br>
<br>Here</br>
<br>Ivan</br>
<br>Geng</br>
</td>
               <td style="text-align: center; vertical-align: center; width:45%">
                <table width="100%" border="2" bordercolor="black" style="font-size:12px;color:black" cellspacing="1" FRAME="box">
<TBODY>
<xsl:for-each select="TestResult/ConfigSummary/Field">
          <tr>
		<td><xsl:value-of select="Argument" /></td>
		<td><xsl:value-of select="Value" /></td>            	
          </tr>
</xsl:for-each>
 </TBODY>
    </table>           
                </td>
        </tr>
</THEAD>
    </table>
<br></br>
<font size="5"><b>Test Components Summary</b></font>
<table id="componentsummary" width="100%" border="2" bordercolor="black" style="font-size:13px;color:black; text-align:center;vertical-align:center;" cellspacing="1" FRAME="box">
<THEAD>
	<tr>
	<td style="background-color:orange">
               Action
                </td>
            <td style="background-color:orange">
               Test Component Name
                </td>
	<td style="background-color:orange">
               Duration
                </td>
<td style="background-color:orange">
               Start Time
                </td>
<td style="background-color:orange">
               End Time
                </td>
               <td style="background-color:orange">
                Test Step              
                </td>
                <td style="background-color:orange">
                 PASS               
                </td>
                <td style="background-color:orange">
               FAIL
                </td>
		<td style="background-color:orange">
               BLOCK
                </td>
		
        </tr>
</THEAD>
<TBODY>

<xsl:for-each select="TestResult/ComponentSummary/Field">
          <tr>
		<td><xsl:value-of select="Action" /></td>
		<td style="color:blue">
		<div onclick="setTab(this.id)">
			<xsl:attribute name="id">
				<xsl:value-of select="concat('td_',Component_Name)"/>
			</xsl:attribute>
		<u><xsl:value-of select="Component_Name" /></u></div></td>
		<td><xsl:value-of select="Duration" /></td>
		<td><xsl:value-of select="Start_Time" /></td>
		<td><xsl:value-of select="End_Time" /></td>
		<td><xsl:value-of select="Test_Step" /></td>
		<td style="color:green"><xsl:value-of select="PASS" /></td>
		<td style="color:red"><xsl:value-of select="FAIL" /></td>
		<td style="color:blue"><xsl:value-of select="BLOCK" /></td>
            	
          </tr>
</xsl:for-each>      

 </TBODY>
    </table>
   
</div><!-- con_one_1 -->

<xsl:apply-templates select="TestResult//TestComponent"/>

</div>
</div>
  </body>
</html>

</xsl:template>

<!-- template to show each Component test result details  -->
<xsl:template match="TestComponent">
<div style="display:none" >
	<xsl:attribute name="id">
		<xsl:value-of select="concat('div_', @name)"/>
	</xsl:attribute>
	<table width="100%" border="2" bordercolor="black" style="font-size:13px;color:black" cellspacing="1" FRAME="box" >
	<xsl:attribute name="id">
		<xsl:value-of select="concat('table_', @name)"/>
	 </xsl:attribute>
<THEAD>
	<tr>
            <td style="text-align: center; vertical-align: center; background-color:orange">
                COMPONENT
                </td>
               <td style="text-align: center; vertical-align: center; background-color:orange">
                TEST GROUP                
                </td>
                <td style="text-align: center; vertical-align: center; background-color:orange; width:5%">
                 CASE ID                
                </td>
                <td style="text-align: center; vertical-align: center; background-color:orange; width:25%">
               CASE DESCRIPTION
                </td>
		<td style="text-align: center; vertical-align: center; background-color:orange">
               Expected Result
                </td>
		<td style="text-align: center; vertical-align: center; background-color:orange">
                RESULT
                </td>
               <td style="text-align: center; vertical-align: center; background-color:orange; width:10%">
                Defect/Note               
                </td>   
                <td style="text-align: center; vertical-align: center; background-color:orange">
                 SCREENSHOT
                </td>
                <td style="text-align: center; vertical-align: center; background-color:orange">
               START TIME
                </td>
		<td style="text-align: center; vertical-align: center; background-color:orange">
               END TIME
                </td>
        </tr>
</THEAD>
<TBODY>
  <xsl:for-each select="Step">
	  <tr>
		<td><xsl:value-of select="COMPONENT" /></td>
		<td><xsl:value-of select="Test_Group" /></td>
		<td style="text-align: center; vertical-align: center;"><xsl:value-of select="Test_CaseID" /></td>
		<td><xsl:value-of select="CASE_DESCRIPTION" /></td>
		<td><xsl:value-of select="Expected" /></td>
		<td><xsl:value-of select="Result"/></td>
		<td><xsl:value-of select="Comment" /></td>
		<td valign="middle"><img border="0" width="80" height="60" onclick="yiru(this);">
		<xsl:attribute name="SRC">
		<xsl:value-of select="SCREENSHOT"/>
		</xsl:attribute></img></td>
		<td><xsl:value-of select="Start_Time" /></td>
		<td><xsl:value-of select="End_Time" /></td>
	  </tr>
 </xsl:for-each>
 </TBODY>
    </table>
</div>

</xsl:template>

<!-- template to show each Component name  -->
<xsl:template match="Component_Name">
	<li  onclick="setTab(this.id)">
		<xsl:attribute name="id">
			<xsl:value-of select="concat('li_',.)"/>
		</xsl:attribute>
		<xsl:value-of select="."/>
	</li>
</xsl:template>

</xsl:stylesheet>