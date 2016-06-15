package org.action;

import java.util.List;
import java.util.Map;

import org.model.Kcb;
import org.service.KcService;
import org.tool.Pager;

import com.opensymphony.xwork2.ActionContext;
import com.opensymphony.xwork2.ActionSupport;

public class KcAction extends ActionSupport{
	private Kcb kcb;
	private KcService kcService;
	/**
	 * @return the kcb
	 */
	public Kcb getKcb() {
		return kcb;
	}
	/**
	 * @param kcb the kcb to set
	 */
	public void setKcb(Kcb kcb) {
		this.kcb = kcb;
	}
	/**
	 * @return the kcService
	 */
	public KcService getKcService() {
		return kcService;
	}
	/**
	 * @param kcService the kcService to set
	 */
	public void setKcService(KcService kcService) {
		this.kcService = kcService;
	}
	/* (non-Javadoc)
	 * @see com.opensymphony.xwork2.ActionSupport#execute()
	 */
	@Override
	public String execute() throws Exception {
		// TODO Auto-generated method stub
		List list=kcService.findAll();
		Map request=(Map)ActionContext.getContext().get("request");
		request.put("list", list);
		return this.SUCCESS;
	}
	
	public String addKcView()throws Exception{
		 return	SUCCESS;
	 }
	public String addKc()throws Exception{
		kcService.save(kcb);
		 return	SUCCESS;
	 }
	public String deleteKc() throws Exception{
		kcService.delete(kcb.getKch());
		return this.SUCCESS;
	}
	

}
