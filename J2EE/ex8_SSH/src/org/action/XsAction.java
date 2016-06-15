package org.action;
import java.io.File;
import java.io.FileInputStream;
import java.util.List;
import java.util.Map;
import javax.servlet.ServletOutputStream;
import javax.servlet.http.HttpServletResponse;
import org.apache.struts2.ServletActionContext;
import org.model.Xsb;
import org.service.XsService;
import org.service.ZyService;
import org.tool.Pager;
import com.opensymphony.xwork2.ActionContext;
import com.opensymphony.xwork2.ActionSupport;
public class XsAction extends ActionSupport{
	private int pageNow=1;
	private int pageSize=8;
	//存放专业集合
	private List list1;
	public void setList1(List list) {
		this.list1 = list;
	}
	 public List getList1(){
		 return zyService.getAll();//返回专业集合
	 }
	private Xsb xs;
	private XsService xsService;
	private ZyService zyService;
	public void setZyService(ZyService zyService) {
		this.zyService = zyService;
	}
	public int getPageNow() {
		return pageNow;
	}
	public void setPageNow(int pageNow) {
		this.pageNow = pageNow;
	}
	public int getPageSize() {
		return pageSize;
	}
	public void setPageSize(int pageSize) {
		this.pageSize = pageSize;
	}
	public String execute() throws Exception {
		System.out.println(this.getPageNow());
		List list=xsService.findAll(pageNow,pageSize);
		Map request=(Map)ActionContext.getContext().get("request");
		Pager page=new Pager(getPageNow(),xsService.findXsSize());
		request.put("list", list);
		request.put("page", page);
		return SUCCESS;
	}
	public String addXs() throws Exception{
		Xsb stu=new Xsb();
		String xh1=xs.getXh();
		if(xsService.find(xh1)!=null){
			return ERROR;
		}
		stu.setXh(xs.getXh());
		stu.setXm(xs.getXm());
		stu.setZxf(xs.getZxf());
		stu.setBz(xs.getBz());
		stu.setZyb(zyService.getOneZy(xs.getZyb().getId()));
		xsService.save(stu);
		return SUCCESS;
	}
	public String deleteXs() throws Exception{
		String xh=xs.getXh();
		xsService.delete(xh);
		return SUCCESS;
	}
	 public String updateXsView()throws Exception{
		 String xh=xs.getXh();
		 Xsb xsInfo=xsService.find(xh);
		 List zys=zyService.getAll();
		 Map request=(Map)ActionContext.getContext().get("request");
		 request.put("xsInfo", xsInfo);
		 request.put("zys", zys);
		 return SUCCESS;
	 }
	 public String updateXs()throws Exception{
		 Xsb xs1=xsService.find(xs.getXh());
		 xs1.setXm(xs.getXm());
		 xs1.setZyb(zyService.getOneZy(xs.getZyb().getId()));
		 xs1.setZxf(xs.getZxf());
		 xs1.setBz(xs.getBz());
		 Map request=(Map)ActionContext.getContext().get("request");
		 xsService.update(xs1);
		 return SUCCESS;
	 }

	 public String findXs()throws Exception{
		 String xh=xs.getXh();
		 Xsb stu2=xsService.find(xh);
		 Map request=(Map)ActionContext.getContext().get("request");
		 request.put("xs", stu2);
		 return SUCCESS;
	 }
	 public String addXsView()throws Exception{
		 return	SUCCESS;
	 }
	public Xsb getXs() {
		return xs;
	}
	public void setXs(Xsb xs) {
		this.xs = xs;
	}
	public XsService getXsService() {
		return xsService;
	}
	public void setXsService(XsService xsService) {
		this.xsService = xsService;
	}
}
