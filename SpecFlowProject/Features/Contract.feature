@Chromium
Feature: Contract_Management

Scenario: สร้างสัญญาฉบับใหม่ ผลลัพธ์คือเมนู Restaurant มองเห็นสัญญาฉบับใหม่
	Given  จากหน้า 'https://delivery-3rd-admin.azurewebsites.net/#/contract'
	And กดปุ่มเพิ่มรายการ
	When กรอกชื่อสัญญา 'สัญญาหน้าฝน'
	When กรอกเปอร์เซ็นต์ที่หักจากร้านอาหาร '30'
	When กรอกค่าส่ง '10'
	Then กดปุ่มยืนยัน
	Then แสดงสัญญาที่สร้างขึ้นมาใหม่ 'Contract : สัญญาหน้าฝน'
	Then ในหน้า 'https://delivery-3rd-admin.azurewebsites.net/#/contract'