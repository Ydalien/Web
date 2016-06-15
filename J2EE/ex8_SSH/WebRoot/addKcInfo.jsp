<%@ page language="java" import="java.util.*" pageEncoding="UTF-8"%>
<%@ taglib uri="/struts-tags" prefix="s"%>

<html>
  <head>
   </head>
  
  <body bgcolor="#D9DFAA">
   <h3>
			请填写课程信息
		</h3>
		<hr width="700" align="left">
		<s:form action="addKc" method="post">
			<table border="0" cellspacing="0" cellpadding="1">
				<tr>
					<td>
						<s:textfield name="kcb.kch" label="课程号" value=""></s:textfield>
					</td>
				</tr>
				<tr>
					<td>
						<s:textfield name="kcb.kcm" label="课程名" value=""></s:textfield>
					</td>
				</tr>
				<tr>
					<td>
						<s:textfield name="kcb.kxxq" label="开课学期" value=""></s:textfield>
					</td>
				</tr>
				<tr>
					<td>
						<s:textfield name="kcb.xs" label="学时" value=""></s:textfield>
					</td>
				</tr>
				<tr>
					<td>
						<s:textfield name="kcb.xf" label="学分" value=""></s:textfield>
					</td>
				</tr>
			</table>
			<p>
				<input type="submit" value="添加" />
				<input type="reset" value="重置" />
		</s:form>
  </body>
</html>
