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
<xsl:comment>
<![CDATA[
function setTab(name,cursel,n){

for(i=1;i<=n;i++){
var menu=document.getElementById(name+i);
var con=document.getElementById("con_"+name+"_"+i);
menu.className=i==cursel?"hover":"";
con.style.display=i==cursel?"block":"none";

}
if(cursel != 1){
var index = cursel -1;
changecolor("T"+index);
}
}


function changecolorSummary1(){
document.getElementById("summary1").rows[0].style.backgroundColor="lime";
document.getElementById("summary1").rows[0].style.fontWeight="bold";
document.getElementById("summary1").rows[1].style.backgroundColor="Red";
document.getElementById("summary1").rows[1].style.color="white";
document.getElementById("summary1").rows[1].style.fontWeight="bold";
document.getElementById("summary1").rows[2].style.backgroundColor="royalblue";
document.getElementById("summary1").rows[2].style.color="white";
document.getElementById("summary1").rows[2].style.fontWeight="bold";

}

function setlink(){

for(var i=1;i<document.getElementById("componentsummary").rows.length;i++){
	var ei = document.getElementById("componentsummary").rows[i].cells(1);
		if(ei.innerText == "Installation")
			{ei.onclick= new Function("setTab('one',2,15)");}
		else if(ei.innerText == "Re-launch_Pad")
			{ei.onclick= new Function("setTab('one',3,15)");}	
				
		else if(ei.innerText == "Solution_Center")
			{ei.onclick= new Function("setTab('one',4,15)");}
		else if(ei.innerText == "Readme")
			{ei.onclick= new Function("setTab('one',5,15)");}
		else if(ei.innerText == "PPUI")
			{ei.onclick= new Function("setTab('one',6,15)");}
		else if(ei.innerText == "Print")
			{ei.onclick= new Function("setTab('one',7,15)");}
		else if(ei.innerText == "Scan")
			{ei.onclick= new Function("setTab('one',8,15)");}
		else if(ei.innerText == "Copy")
			{ei.onclick= new Function("setTab('one',9,15)");}
		else if(ei.innerText == "Fax")
			{ei.onclick= new Function("setTab('one',10,15)");}
		else if(ei.innerText == "Mars")
			{ei.onclick= new Function("setTab('one',11,15)");}
		else if(ei.innerText == "ToolBox")
			{ei.onclick= new Function("setTab('one',12,15)");}
		else if(ei.innerText == "HP_Update")
			{ei.onclick= new Function("setTab('one',13,15)");}
		else if(ei.innerText == "Shop_for_Supplies")
			{ei.onclick= new Function("setTab('one',14,15)");}
		else if(ei.innerText == "Uninstall")
			{ei.onclick= new Function("setTab('one',15,15)");}
	}

}


function changecolor(t){

for(var i=1;i<document.getElementById(t).rows.length;i++){
	var ei = document.getElementById(t).rows[i].cells(5);
		if(ei.innerText == "FAILED")
			{ei.style.color = "red";}

		else if(ei.innerText == "BLOCKED")
			{ei.style.color = "blue";}

		else if(ei.innerText == "PASSED")
			{ei.style.color = "green";}

	}

}

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

     
   
]]>

</xsl:comment>
</script>
</head>
<body background=".\\XSL\\space.jpg" style="color:black;"  onload="changecolorSummary1(); setlink();"> 
<div id="big_image" style="position: absolute; left:0px; top:0px; display: none; border: 0px solid #f4f4f4;" class="dragAble" onmouseout="yichu();">
    </div>
<div id="Tab1">
<div id="Menubox" style="position: absolute; left:10px; top: 0px; top:expression(offsetParent.scrollTop); z-index: 1;">
<ul>
<li id="one1" onclick="setTab('one',1,15);"  class="hover">Summary</li>
<li id="one2" onclick="setTab('one',2,15); changecolor('T1');">Installation</li>
<li id="one3" onclick="setTab('one',3,15); changecolor('T2');">Re-launch Pad</li>
<li id="one4" onclick="setTab('one',4,15); changecolor('T3');">Solution Center</li>
<li id="one5" onclick="setTab('one',5,15); changecolor('T4');">Readme</li>
<li id="one6" onclick="setTab('one',6,15); changecolor('T5');">PPUI</li>
<li id="one7" onclick="setTab('one',7,15); changecolor('T6');">Print</li>
<li id="one8" onclick="setTab('one',8,15); changecolor('T7');">Scan</li>
<li id="one9" onclick="setTab('one',9,15); changecolor('T8');">Copy</li>
<li id="one10" onclick="setTab('one',10,15); changecolor('T9');">Fax</li>
<li id="one11" onclick="setTab('one',11,15); changecolor('T10');">Mars</li>
<li id="one12" onclick="setTab('one',12,15); changecolor('T11');">ToolBox</li>
<li id="one13" onclick="setTab('one',13,15); changecolor('T12');">HP Update</li>
<li id="one14" onclick="setTab('one',14,15); changecolor('T13');">Shop for Supplies</li>
<li id="one15" onclick="setTab('one',15,15); changecolor('T14');">Uninstall</li>
</ul>
</div>


<div id="Contentbox" >
<div id="con_one_1" style="font-size: 20px; text-align: center; vertical-align: Top;">
<font size="5"><b>RDV Automation Test Summary</b></font>
<table width="100%" border="2" bordercolor="black" style="font-size:11px;color:black" cellspacing="1" FRAME="box">
<THEAD>
	<tr>
            <td style="text-align: center; vertical-align: center; width:35%">
               <table id="Summary1" width="100%" border="2" bordercolor="black" style="font-size:12px;color:black" cellspacing="1" FRAME="box">
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
<font size="3"><b><u>HP Confidential</u></b></font>
<br></br>
<br>THIS DOCUMENT CONTAINS CONFIDENTIAL, PROPRIETARY INFORMATION THAT IS HEWLETT-PACKARD PROPERTY.</br>
<br></br>
<br>DO NOT DISCLOSE TO OR DUPLICATE FOR OTHERS EXCEPT AS AUTHORIZED BY HP.</br>
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
		<td style="color:blue"><u><xsl:value-of select="Component_Name" /></u></td>
		<td><xsl:value-of select="Duration" /></td>
		<td><xsl:value-of select="Start_Time" /></td>
		<td><xsl:value-of select="End_Time" /></td>
		<td><xsl:value-of select="Test_Step" /></td>
		<td style="color:green"><xsl:value-of select="PASS" /></td>
		<td style="color:red"><xsl:value-of select="FAIL" /></td>
		<td style="color:blue"><xsl:value-of select="BLOCK" /></td>
            	
          </tr>
</xsl:for-each>
          <!--<tr>
		<td>1</td>
		<td style="color:blue"><u>Installation</u></td>
		<td></td>
		<td><xsl:value-of select="//Installation//Step[1]//Start_Time" /></td>
		<td><xsl:value-of select="//Installation//Step[count(//Installation//Step)]//End_Time" /></td>
		<td><xsl:value-of select="count(//Installation//Step)" /></td>
		<td style="color:green"><xsl:value-of select="count(//Installation//Step[./Result='PASSED']) div count(//Installation//Step)" /></td>
		<td style="color:red"><xsl:value-of select="count(//Installation//Step[./Result='FAILED']) div count(//Installation//Step)" /></td>
		<td style="color:blue"><xsl:value-of select="count(//Installation//Step[./Result='BLOCKED']) div count(//Installation//Step)" /></td>
            	
          </tr>-->



 </TBODY>
    </table>
   
</div>

<div id="con_one_2" style="display:none">
<table id="T1" width="100%" border="2" bordercolor="black" style="font-size:13px;color:black" cellspacing="1" FRAME="box">
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
<xsl:for-each select="TestResult/Installation/Step">
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
<div id="con_one_3" style="display:none">
<table id="T2" width="100%" border="2" bordercolor="black" style="font-size:13px;color:black" cellspacing="1" FRAME="box">
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
<xsl:for-each select="TestResult/Re-launch_Pad/Step">
          <tr>
		<td><xsl:value-of select="COMPONENT" /></td>
		<td><xsl:value-of select="Test_Group" /></td>
		<td style="text-align: center; vertical-align: center;"><xsl:value-of select="Test_CaseID" /></td>
		<td><xsl:value-of select="CASE_DESCRIPTION" /></td>
		<td><xsl:value-of select="Expected" /></td>
            	<td><xsl:value-of select="Result" /></td>
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
<div id="con_one_4" style="display:none">
<table id="T3" width="100%" border="2" bordercolor="black" style="font-size:13px;color:black" cellspacing="1" FRAME="box">
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
<xsl:for-each select="TestResult/Solution_Center/Step">
          <tr>
		<td><xsl:value-of select="COMPONENT" /></td>
		<td><xsl:value-of select="Test_Group" /></td>
		<td style="text-align: center; vertical-align: center;"><xsl:value-of select="Test_CaseID" /></td>
		<td><xsl:value-of select="CASE_DESCRIPTION" /></td>
		<td><xsl:value-of select="Expected" /></td>
            	<td><xsl:value-of select="Result" /></td>
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
<div id="con_one_5" style="display:none">
<table id="T4" width="100%" border="2" bordercolor="black" style="font-size:13px;color:black" cellspacing="1" FRAME="box">
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
<xsl:for-each select="TestResult/Readme/Step">
          <tr>
		<td><xsl:value-of select="COMPONENT" /></td>
		<td><xsl:value-of select="Test_Group" /></td>
		<td style="text-align: center; vertical-align: center;"><xsl:value-of select="Test_CaseID" /></td>
		<td><xsl:value-of select="CASE_DESCRIPTION" /></td>
		<td><xsl:value-of select="Expected" /></td>
            	<td><xsl:value-of select="Result" /></td>
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
<div id="con_one_6" style="display:none">
<table id="T5" width="100%" border="2" bordercolor="black" style="font-size:13px;color:black" cellspacing="1" FRAME="box">
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
<xsl:for-each select="TestResult/PPUI/Step">
          <tr>
		<td><xsl:value-of select="COMPONENT" /></td>
		<td><xsl:value-of select="Test_Group" /></td>
		<td style="text-align: center; vertical-align: center;"><xsl:value-of select="Test_CaseID" /></td>
		<td><xsl:value-of select="CASE_DESCRIPTION" /></td>
		<td><xsl:value-of select="Expected" /></td>
            	<td><xsl:value-of select="Result" /></td>
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
<div id="con_one_7" style="display:none">
<table id="T6" width="100%" border="2" bordercolor="black" style="font-size:13px;color:black" cellspacing="1" FRAME="box">
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
<xsl:for-each select="TestResult/Print/Step">
          <tr>
		<td><xsl:value-of select="COMPONENT" /></td>
		<td><xsl:value-of select="Test_Group" /></td>
		<td style="text-align: center; vertical-align: center;"><xsl:value-of select="Test_CaseID" /></td>
		<td><xsl:value-of select="CASE_DESCRIPTION" /></td>
		<td><xsl:value-of select="Expected" /></td>
            	<td><xsl:value-of select="Result" /></td>
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
<div id="con_one_8" style="display:none">
<table id="T7" width="100%" border="2" bordercolor="black" style="font-size:13px;color:black" cellspacing="1" FRAME="box">
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
<xsl:for-each select="TestResult/Scan/Step">
          <tr>
		<td><xsl:value-of select="COMPONENT" /></td>
		<td><xsl:value-of select="Test_Group" /></td>
		<td style="text-align: center; vertical-align: center;"><xsl:value-of select="Test_CaseID" /></td>
		<td><xsl:value-of select="CASE_DESCRIPTION" /></td>
		<td><xsl:value-of select="Expected" /></td>
            	<td><xsl:value-of select="Result" /></td>
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
<div id="con_one_9" style="display:none">
<table id="T8" width="100%" border="2" bordercolor="black" style="font-size:13px;color:black" cellspacing="1" FRAME="box">
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
<xsl:for-each select="TestResult/Copy/Step">
          <tr>
		<td><xsl:value-of select="COMPONENT" /></td>
		<td><xsl:value-of select="Test_Group" /></td>
		<td style="text-align: center; vertical-align: center;"><xsl:value-of select="Test_CaseID" /></td>
		<td><xsl:value-of select="CASE_DESCRIPTION" /></td>
		<td><xsl:value-of select="Expected" /></td>
            	<td><xsl:value-of select="Result" /></td>
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
<div id="con_one_10" style="display:none">
<table id="T9" width="100%" border="2" bordercolor="black" style="font-size:13px;color:black" cellspacing="1" FRAME="box">
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
<xsl:for-each select="TestResult/Fax/Step">
          <tr>
		<td><xsl:value-of select="COMPONENT" /></td>
		<td><xsl:value-of select="Test_Group" /></td>
		<td style="text-align: center; vertical-align: center;"><xsl:value-of select="Test_CaseID" /></td>
		<td><xsl:value-of select="CASE_DESCRIPTION" /></td>
		<td><xsl:value-of select="Expected" /></td>
            	<td><xsl:value-of select="Result" /></td>
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
<div id="con_one_11" style="display:none">
<table id="T10" width="100%" border="2" bordercolor="black" style="font-size:13px;color:black" cellspacing="1" FRAME="box">
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
<xsl:for-each select="TestResult/Mars/Step">
          <tr>
		<td><xsl:value-of select="COMPONENT" /></td>
		<td><xsl:value-of select="Test_Group" /></td>
		<td style="text-align: center; vertical-align: center;"><xsl:value-of select="Test_CaseID" /></td>
		<td><xsl:value-of select="CASE_DESCRIPTION" /></td>
		<td><xsl:value-of select="Expected" /></td>
            	<td><xsl:value-of select="Result" /></td>
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
<div id="con_one_12" style="display:none">
<table id="T11" width="100%" border="2" bordercolor="black" style="font-size:13px;color:black" cellspacing="1" FRAME="box">
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
<xsl:for-each select="TestResult/ToolBox/Step">
          <tr>
		<td><xsl:value-of select="COMPONENT" /></td>
		<td><xsl:value-of select="Test_Group" /></td>
		<td style="text-align: center; vertical-align: center;"><xsl:value-of select="Test_CaseID" /></td>
		<td><xsl:value-of select="CASE_DESCRIPTION" /></td>
		<td><xsl:value-of select="Expected" /></td>
            	<td><xsl:value-of select="Result" /></td>
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
<div id="con_one_13" style="display:none">
<table id="T12" width="100%" border="2" bordercolor="black" style="font-size:13px;color:black" cellspacing="1" FRAME="box">
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
<xsl:for-each select="TestResult/HP_Update/Step">
          <tr>
		<td><xsl:value-of select="COMPONENT" /></td>
		<td><xsl:value-of select="Test_Group" /></td>
		<td style="text-align: center; vertical-align: center;"><xsl:value-of select="Test_CaseID" /></td>
		<td><xsl:value-of select="CASE_DESCRIPTION" /></td>
		<td><xsl:value-of select="Expected" /></td>
            	<td><xsl:value-of select="Result" /></td>
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
<div id="con_one_14" style="display:none">
<table id="T13" width="100%" border="2" bordercolor="black" style="font-size:13px;color:black" cellspacing="1" FRAME="box">
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
<xsl:for-each select="TestResult/Shop_for_Supplies/Step">
          <tr>
		<td><xsl:value-of select="COMPONENT" /></td>
		<td><xsl:value-of select="Test_Group" /></td>
		<td style="text-align: center; vertical-align: center;"><xsl:value-of select="Test_CaseID" /></td>
		<td><xsl:value-of select="CASE_DESCRIPTION" /></td>
		<td><xsl:value-of select="Expected" /></td>
            	<td><xsl:value-of select="Result" /></td>
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
<div id="con_one_15" style="display:none">
<table id="T14" width="100%" border="2" bordercolor="black" style="font-size:13px;color:black" cellspacing="1" FRAME="box">
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
<xsl:for-each select="TestResult/Uninstall/Step">
          <tr>
		<td><xsl:value-of select="COMPONENT" /></td>
		<td><xsl:value-of select="Test_Group" /></td>
		<td style="text-align: center; vertical-align: center;"><xsl:value-of select="Test_CaseID" /></td>
		<td><xsl:value-of select="CASE_DESCRIPTION" /></td>
		<td><xsl:value-of select="Expected" /></td>
            	<td><xsl:value-of select="Result" /></td>
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
</div>
</div>
  </body>
</html>

</xsl:template>
</xsl:stylesheet>