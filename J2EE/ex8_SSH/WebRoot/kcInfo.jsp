<%@ page language="java" pageEncoding="UTF-8"%>
<%@ taglib uri="/struts-tags" prefix="s"%>
<html>
	<head>
	</head>
  <body bgcolor="#D9DFAA">
  <table border="1" cellspacing="1" cellpadding="8" width="700">
  		<tr align="center" bgcolor="silver" >
  			<th>课程号</th><th>课程名</th><th>开课学期</th>
  			<th>学时</th><th>学分</th>
  			<th>操作</th>
  		</tr>
  		<s:iterator value="#request.list" id="kc">
  		<tr>
			<td><s:property value="#kc.kch"/></td>
			<td><s:property value="#kc.kcm"/></td>
			<td><s:property value="#kc.kxxq"/></td>
			<td><s:property value="#kc.xs"/></td>
			<td><s:property value="#kc.xf"/></td>
			<td> <a href="deleteKc.action?kcb.kch=<s:property value="#kc.kch"/>" onClick="if(!confirm('确定删除该信息吗？'))return false;else return true;">删除</a> </td>
			
		</tr>
		</s:iterator>
		
		
  	</table>
  </body>
</html>