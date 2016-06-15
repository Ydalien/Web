<%@ page language="java" pageEncoding="UTF-8"%>
<%@ taglib uri="/struts-tags" prefix="s"%>
<html>
	<head>
	</head>
	 <script type="text/javascript" src="images/calendar.js">
	 </script>
	<body bgcolor="#D9DFAA">
		<h3>
			请填写学生信息
		</h3>
		<hr width="700" align="left">
		<s:form action="addXs" method="post"
			enctype="multipart/form-data" validate="true">
			<table border="0" cellspacing="0" cellpadding="1">
				<tr>
					<td>
						<s:textfield name="xs.xh" label="学号" value=""></s:textfield>
					</td>
				</tr>
				<tr>
					<td>
						<s:textfield name="xs.xm" label="姓名" value=""></s:textfield>
					</td>
				</tr>
				<tr>
					<s:select  name="xs.zyb.id" list="list1" listKey="id" listValue="zym"
					 headerKey="0" headerValue="--请选择专业--" label="专业"></s:select>
				</tr>
				<tr>
					<td>
						<s:textfield name="xs.zxf" label="总学分" value=""></s:textfield>
					</td>
				</tr>
				<tr>
					<td>
						<s:textfield name="xs.bz" label="备注" value=""></s:textfield>
					</td>
				</tr>
			</table>
			<p>
				<input type="submit" value="添加" />
				<input type="reset" value="重置" />
		</s:form>
		
	</body>
</html>