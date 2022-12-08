using CustomerManagementSystem.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using static System.Collections.Specialized.BitVector32;
using System.ComponentModel.Design;
using System.Net;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementSystem.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MyContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MyContext>>()))
        {
            if (context == null || context.Customer == null)
            {
                throw new ArgumentNullException("Null CustomerManagementSystemContext");
            }

            // Seed data for Customer, Look for any Customers.
            if (!context.Customer.Any())
            {
                context.Customer.AddRange(
                    new tbl_customer {
                        customer_name = "宮崎典子",
                        customer_kana = "ミヤザキノリコ",
                        companyId = 1,
                        section = "総務部",
                        post = "部長",
                        zipcode = "300-1261",
                        address = "つくば市あしび野",
                        tel = "03 - 727 - 8488",
                        staffId = 1,
                        first_action_date = DateTime.Parse("2022/6/15"),
                        memo = "メモ1",
                        input_date = DateTime.Parse("2022/6/15"),
                        input_staff_name = "桐生祥秀",
                        update_date = DateTime.Parse("2022/6/15"),
                        update_staff_name = "桐生祥秀",
                        delete_flag = false
                    },
                    new tbl_customer
                    {
                        customer_name = "尾松佳美",
                        customer_kana = "オマツヨシミ",
                        companyId = 3,
                        section = "設計部",
                        post = "担当",
                        zipcode = "300-0341",
                        address = "稲敷郡阿見町うずら野",
                        tel = "03 - 528 - 3711",
                        staffId = 3,
                        first_action_date = DateTime.Parse("2020/1/1"),
                        memo = "メモ3",
                        input_date = DateTime.Parse("2020/1/1"),
                        input_staff_name = "松本尚子",
                        update_date = DateTime.Parse("2020/1/1"),
                        update_staff_name = "松本尚子",
                        delete_flag = false
                    },
                    new tbl_customer
                    {
                        customer_name = "佐賀陽",
                        customer_kana = "サガヨウ",
                        companyId = 2,
                        section = "製造部",
                        post = "課長",
                        zipcode = "311-2425",
                        address = "潮来市あやめ",
                        tel = "03 - 6216 - 5268",
                        staffId = 2,
                        first_action_date = DateTime.Parse("2020/1/15"),
                        memo = "メモ2",
                        input_date = DateTime.Parse("2020/1/15"),
                        input_staff_name = "足立美由紀",
                        update_date = DateTime.Parse("2020/1/15"),
                        update_staff_name = "足立美由紀",
                        delete_flag = false
                    },
                    new tbl_customer
                    {
                        customer_name = "本塩遼",
                        customer_kana = "ホンシオリョウ",
                        companyId = 4,
                        section = "QA部",
                        post = "主任",
                        zipcode = "300-0028",
                        address = "土浦市おおつ野",
                        tel = "03 - 6488 - 949",
                        staffId = 1,
                        first_action_date = DateTime.Parse("2020/1/29"),
                        memo = "メモ4",
                        input_date = DateTime.Parse("2020/1/29"),
                        input_staff_name = "桐生祥秀",
                        update_date = DateTime.Parse("2020/1/29"),
                        update_staff_name = "桐生祥秀",
                        delete_flag = false
                    },

                    new tbl_customer
                    {
                        customer_name = "谷掛玲子",
                        customer_kana = "タニガケレイコ",
                        companyId = 1,
                        section = "総務部",
                        post = "パート",
                        zipcode = "319-1417",
                        address = "日立市かみあい町",
                        tel = "03 - 8225 - 3243",
                        staffId = 2,
                        first_action_date = DateTime.Parse("2020/4/22"),
                        memo = "メモ5",
                        input_date = DateTime.Parse("2020/4/22"),
                        input_staff_name = "足立美由紀",
                        update_date = DateTime.Parse("2020/4/22"),
                        update_staff_name = "足立美由紀",
                        delete_flag = false
                    },

                    new tbl_customer
                    {
                        customer_name = "近藤晃",
                        customer_kana = "コンドウアキラ",
                        companyId = 2,
                        section = "設計部",
                        post = "部長",
                        zipcode = "300-2668",
                        address = "つくば市かみかわ",
                        tel = "03 - 8071 - 1103",
                        staffId = 3,
                        first_action_date = DateTime.Parse("2020/4/8"),
                        memo = "メモ6",
                        input_date = DateTime.Parse("2020/4/8"),
                        input_staff_name = "松本尚子",
                        update_date = DateTime.Parse("2020/4/8"),
                        update_staff_name = "松本尚子",
                        delete_flag = false
                    },
                    new tbl_customer
                    {
                        customer_name = "福田美紀",
                        customer_kana = "フクダミキ",
                        companyId = 3,
                        section = "製造部",
                        post = "課長",
                        zipcode = "310-0842",
                        address = "水戸市けやき台",
                        tel = "03 - 6978 - 8883",
                        staffId = 1,
                        first_action_date = DateTime.Parse("2020/3/25"),
                        memo = "メモ7",
                        input_date = DateTime.Parse("2020/3/25"),
                        input_staff_name = "桐生祥秀",
                        update_date = DateTime.Parse("2020/3/25"),
                        update_staff_name = "桐生祥秀",
                        delete_flag = false
                    },
                    new tbl_customer
                    {
                        customer_name = "関口裕太",
                        customer_kana = "セキグチユウタ",
                        companyId = 4,
                        section = "QA部",
                        post = "担当",
                        zipcode = "302-0128",
                        address = "守谷市けやき台",
                        tel = "03 - 2793 - 1778",
                        staffId = 2,
                        first_action_date = DateTime.Parse("2020/3/11"),
                        memo = "メモ8",
                        input_date = DateTime.Parse("2020/3/11"),
                        input_staff_name = "足立美由紀",
                        update_date = DateTime.Parse("2020/3/11"),
                        update_staff_name = "足立美由紀",
                        delete_flag = false
                    },
                    new tbl_customer
                    {
                        customer_name = "鳥内啓子",
                        customer_kana = "トリウチケイコ",
                        companyId = 9,
                        section = "設計部",
                        post = "主任",
                        zipcode = "306-0055",
                        address = "古河市けやき平",
                        tel = "03 - 241 - 2105",
                        staffId = 3,
                        first_action_date = DateTime.Parse("2020/2/26"),
                        memo = "メモ9",
                        input_date = DateTime.Parse("2020/2/26"),
                        input_staff_name = "松本尚子",
                        update_date = DateTime.Parse("2020/2/26"),
                        update_staff_name = "松本尚子",
                        delete_flag = false
                    },
                    new tbl_customer
                    {
                        customer_name = "辰巳新",
                        customer_kana = "タツミアラタ",
                        companyId = 10,
                        section = "製造部",
                        post = "パート",
                        zipcode = "306-0308",
                        address = "猿島郡五霞町ごかみらい",
                        tel = "03 - 5277 - 8160",
                        staffId = 1,
                        first_action_date = DateTime.Parse("2020/2/12"),
                        memo = "メモ10",
                        input_date = DateTime.Parse("2020/2/12"),
                        input_staff_name = "桐生祥秀",
                        update_date = DateTime.Parse("2020/2/12"),
                        update_staff_name = "桐生祥秀",
                        delete_flag = false
                    }
                );
            }

            // Seed data of Company
            if (!context.Company.Any())
            {
                context.Company.AddRange(
                    new tbl_company
                    {
                        company_name = "医療法人徳真会　真岡病院 ",
                        company_kana = "モウカビョウイン",
                        delete_flag = false
                    },
                    new tbl_company
                    {
                        company_name = "旭化成ファーマ株式会社 ",
                        company_kana = "アサヒカセイファーマ",
                        delete_flag = false
                    },
                    new tbl_company
                    {
                        company_name = "アステラス製薬株式会社 ",
                        company_kana = "アステラスセイヤク",
                        delete_flag = false
                    },
                    new tbl_company
                    {
                        company_name = "アルフレッサ ",
                        company_kana = "アルフレッサ ",
                        delete_flag = false
                    },
                    new tbl_company
                    {
                        company_name = "エーザイ株式会社 ",
                        company_kana = "エーザイ",
                        delete_flag = false
                    },
                    new tbl_company
                    {
                        company_name = "大塚製薬株式会社 ",
                        company_kana = "オオツカセイヤク",
                        delete_flag = false
                    },
                    new tbl_company
                    {
                        company_name = "小野薬品工業株式会社 ",
                        company_kana = "オノヤクヒンコウギョウ",
                        delete_flag = false
                    },
                    new tbl_company
                    {
                        company_name = "キッセイ薬品工業株式会社 ",
                        company_kana = "キッセイヤクヒンコウギョウ",
                        delete_flag = false
                    },
                    new tbl_company
                    {
                        company_name = "協和キリン株式会社 ",
                        company_kana = "キョウワキリン",
                        delete_flag = false
                    },
                    new tbl_company
                    {
                        company_name = "興和株式会社 ",
                        company_kana = "コウワ",
                        delete_flag = false
                    });
}

            // Seed data of Staff
            if (!context.Staff.Any())
            {
                context.Staff.AddRange(
                    new tbl_staff
                    {
                        staff_name = "桐生祥秀", userId = "1019", password = "pass1019", admin_flag = false, delete_flag = false
                    },
                    new tbl_staff
                    {
                        staff_name = "足立美由紀", userId = "1074", password = "pass1074", admin_flag = false, delete_flag = false
                    },
                    new tbl_staff
                    {
                        staff_name = "松本尚子", userId = "1053", password = "pass1053", admin_flag = false, delete_flag = false
                    },
                    new tbl_staff
                    {
                        staff_name = "柳田大輝", userId = "1103", password = "pass1103", admin_flag = false, delete_flag = false
                    },
                    new tbl_staff
                    {
                         staff_name = "山田真理子", userId = "1042", password = "pass1042", admin_flag = false, delete_flag = false
                   },
                    new tbl_staff
                    {
                        staff_name = "小嶋しげみ", userId = "1052", password = "pass1052", admin_flag = false, delete_flag = false
                    },
                    new tbl_staff
                    {
                        staff_name = "赤渕小百合", userId = "1066", password = "pass1066", admin_flag = false, delete_flag = false
                    },
                    new tbl_staff
                    {
                        staff_name = "宮本大輔", userId = "1017", password = "pass1017", admin_flag = false, delete_flag = false
                    },
                    new tbl_staff
                    {
                        staff_name = "大瀬戸一馬", userId = "1076", password = "pass1076", admin_flag = false, delete_flag = false
                    },
                    new tbl_staff
                    {
                        staff_name = "米田亜紀子", userId = "1098", password = "pass1098", admin_flag = false, delete_flag = false
                    });
            }

            // Seed data of Action
            if (!context.Action.Any())
            {
                context.Action.AddRange(
                    new tbl_action
                    {
                        customerId = 1,
                        action_date = DateTime.Parse("2022/7/30"),
                        action_content = "来店",
                        action_staffId = 4
                    },
                    new tbl_action
                    {
                        customerId = 7,
                        action_date = DateTime.Parse("2022/3/19"),
                        action_content = "電話受け",
                        action_staffId = 8
                    },
                    new tbl_action
                    {
                        customerId = 9,
                        action_date = DateTime.Parse("2022/6/3"),
                        action_content = "来店",
                        action_staffId = 1
                    },
                    new tbl_action
                    {
                        customerId = 9,
                        action_date = DateTime.Parse("2022/2/9"),
                        action_content = "来店",
                        action_staffId = 6
                    },
                    new tbl_action
                    {
                        customerId = 2,
                        action_date = DateTime.Parse("2022/1/2"),
                        action_content = "訪問",
                        action_staffId = 4
                    },
                    new tbl_action
                    {
                        customerId = 7,
                        action_date = DateTime.Parse("2022/1/21"),
                        action_content = "電話受け",
                        action_staffId = 4
                    },
                    new tbl_action
                    {
                        customerId = 4,
                        action_date = DateTime.Parse("2022/6/22"),
                        action_content = "訪問",
                        action_staffId = 6
                    },
                    new tbl_action
                    {
                        customerId = 2,
                        action_date = DateTime.Parse("2022/7/11"),
                        action_content = "電話受け",
                        action_staffId = 6
                    },
                    new tbl_action
                    {
                        customerId = 6,
                        action_date = DateTime.Parse("2022/2/28"),
                        action_content = "訪問",
                        action_staffId = 5
                    },
                    new tbl_action
                    {
                        customerId = 1,
                        action_date = DateTime.Parse("2022/4/7"),
                        action_content = "来店",
                        action_staffId = 9
                    },
                    new tbl_action
                    {
                        customerId = 3,
                        action_date = DateTime.Parse("2022/5/15"),
                        action_content = "電話受け",
                        action_staffId = 1
                    },
                    new tbl_action
                    {
                        customerId = 4,
                        action_date = DateTime.Parse("2022/4/26"),
                        action_content = "訪問",
                        action_staffId = 7
                    }
                );
            }
            context.SaveChanges();
        }
    }
}