package org.dao.imp;
import java.util.List;
import org.dao.KcDao;
import org.hibernate.*;
import org.model.Kcb;
import org.springframework.orm.hibernate3.support.HibernateDaoSupport;
public class KcDaoImp extends HibernateDaoSupport implements KcDao{
	public void delete(String kch) {
		getHibernateTemplate().delete(find(kch));
	}
	public Kcb find(String kch) {
		List list=getHibernateTemplate().find("from Kcb where kch=?",kch);
		if(list.size()>0)
			return (Kcb)list.get(0);
		else
			return null;
	}
	public List findAll(int pageNow, int pageSize) {
		Session session=getHibernateTemplate().getSessionFactory().openSession();
		Transaction ts=session.beginTransaction();
		Query query=session.createQuery("from Kcb order by kch");
		int firstResult=(pageNow-1)*pageSize;
		query.setFirstResult(firstResult);
		query.setMaxResults(pageSize);
		List list=query.list();
		ts.commit();
		session.close();
		session=null;
		return list;
	}
	
	public int findKcSize() {
		return getHibernateTemplate().find("from Kcb").size();
	}
	public void save(Kcb kc) {
		getHibernateTemplate().save(kc);
	}
	public void update(Kcb kc) {
		getHibernateTemplate().update(kc);
	}
	public List findAll() {
		Session session=getHibernateTemplate().getSessionFactory().openSession();
		Transaction ts=session.beginTransaction();
		Query query=session.createQuery("from Kcb order by kch");
		List list=query.list();
		ts.commit();
		session.close();
		session=null;
		return list;
	}
}
