package org.model;

/**
 * Xsb entity. @author MyEclipse Persistence Tools
 */

public class Xsb implements java.io.Serializable {

	// Fields

	private String xh;
	private Zyb zyb;
	private String xm;
	//private Integer zyId;
	private Integer zxf;
	private String bz;

	// Constructors

	/** default constructor */
	public Xsb() {
	}

	/** minimal constructor */
	public Xsb(String xm) {
		this.xm = xm;
		//this.zyId = zyId;
	}

	/** full constructor */
	public Xsb(Zyb zyb, String xm, Integer zxf, String bz) {
		this.zyb = zyb;
		this.xm = xm;
		//this.zyId = zyId;
		this.zxf = zxf;
		this.bz = bz;
	}

	// Property accessors

	public String getXh() {
		return this.xh;
	}

	public void setXh(String xh) {
		this.xh = xh;
	}

	public Zyb getZyb() {
		return this.zyb;
	}

	public void setZyb(Zyb zyb) {
		this.zyb = zyb;
	}
	
	public String getXm() {
		return this.xm;
	}

	public void setXm(String xm) {
		this.xm = xm;
	}
/*
	public Integer getZyId() {
		return this.zyId;
	}

	public void setZyId(Integer zyId) {
		this.zyId = zyId;
	}
*/
	public Integer getZxf() {
		return this.zxf;
	}

	public void setZxf(Integer zxf) {
		this.zxf = zxf;
	}

	public String getBz() {
		return this.bz;
	}

	public void setBz(String bz) {
		this.bz = bz;
	}

}