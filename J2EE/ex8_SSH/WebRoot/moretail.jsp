<%@ page language="java" import="java.util.*" pageEncoding="UTF-8"%>
<%@ taglib uri="/struts-tags" prefix="s" %>
<html>
  <head>
  </head>
  
  <body bgcolor="#D9DFAA">
  		<h3>该学生信息如下：</h3>
  		<s:set name="xs" value="#request.xs"></s:set>
  		<s:form action="xsInfo.action" method="post">
  			<table border="0" cellpadding="5">
  				<tr>
  					<td>学号：</td>
  					<td width="100"><s:property value="#xs.xh"/></td>  					
  				</tr>
  				<tr>
  					<td>姓名：</td>
  					<td width="100"><s:property value="#xs.xm"/></td>
  				</tr>
				<tr>
					<td>专业：</td>
  					<td width="100"><s:property value="#xs.zyb.zym"/></td>
  				</tr>
  				<tr>
  					<td>总学分</td>
  					<td width="100"><s:property value="#xs.zxf"/></td>
  				</tr>
  				<tr>
  					<td>备注</td>
  					<td width="100"><s:property value="#xs.bz"/></td>
  				</tr>  				
  			</table>
  			<input type="submit" value="返回"/>
  		</s:form>
  </body>
</html>