CREATE VIEW [dbo].[CustomerView]
	AS SELECT Customer.Id, customer_name, customer_kana, section, post, 
		first_action_date, zipcode, Customer.address, tel, memo,
		update_date, update_staff_name,
		Company.company_name, Company.company_kana, 
		Staff.staff_name
		FROM [Customer]
			INNER JOIN Staff on Customer.staffId = Staff.Id
			INNER JOIN Company on Customer.companyId = Company.Id