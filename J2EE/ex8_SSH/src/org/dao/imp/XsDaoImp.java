package org.dao.imp;
import java.util.List;
import org.dao.XsDao;
import org.hibernate.Query;
import org.hibernate.Session;
import org.hibernate.Transaction;
import org.model.Xsb;
import org.springframework.orm.hibernate3.support.HibernateDaoSupport;
public class XsDaoImp extends HibernateDaoSupport implements XsDao{
	public void delete(String xh) {
		getHibernateTemplate().delete(find(xh));
	}
	public Xsb find(String xh) {
		List list=getHibernateTemplate().find("from Xsb where xh=?",xh);
		if(list.size()>0)
			return (Xsb)list.get(0);
		else
			return null;
	}
	public List findAll(int pageNow, int pageSize) {
		try{
			Session session=getHibernateTemplate().getSessionFactory().openSession();
			Transaction ts=session.beginTransaction();
			Query query=session.createQuery("from Xsb order by xh");
			int firstResult=(pageNow-1)*pageSize;
			query.setFirstResult(firstResult);
			query.setMaxResults(pageSize);
			List list=query.list();
			ts.commit();
			session.close();
			session=null;
			return list;
		}catch(Exception e){
			e.printStackTrace();
			return null;
		}
	}
	public int findXsSize() {
		return getHibernateTemplate().find("from Xsb").size();
	}
	public void save(Xsb xs) {
		getHibernateTemplate().save(xs);
	}
	public void update(Xsb xs) {
		getHibernateTemplate().update(xs);
	}

}
