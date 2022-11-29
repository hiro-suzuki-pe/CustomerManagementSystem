CREATE VIEW [dbo].Test
	AS SELECT Customer.Id, customer_name, customer_kana, companyID, section, post, zipcode, address, tel, 
		Staff.staff_name, first_action_date, memo FROM Customer inner join Staff on Customer.staffID = Staff.Id
