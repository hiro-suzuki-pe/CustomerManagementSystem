using CustomerManagementSystem.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using static System.Collections.Specialized.BitVector32;
using System.ComponentModel.Design;

using System.Net;

using System.Reflection.Emit;

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

            // Look for any movies.
            if (context.Customer.Any())
            {
                return;   // DB has been seeded
            }

            context.Customer.AddRange(
                new Customer {
                    customer_name = "宮崎典子",
                    customer_kana = "ミヤザキノリコ",
                    companyId = 1,
                    section = 総務部,
                    post = "部長",
                    zipcode = "300-1261",
                    address = "つくば市あしび野",
                    tel = 5029,
                    staffId = 1,
                    first_action_date = 44562,
                    memo = "メモ1",
                    input_date = 44532,
                    input_staff_name = "桐生祥秀",
                    update_date = 44532,
                    update_staff_name = "桐生祥秀",
                    delete_flag = false
                },
                new Customer
                {
                    customer_name = "尾松佳美",
                    customer_kana = "オマツヨシミ",
                    companyId = 3,
                    section = 設計部,
                    post = "担当",
                    zipcode = "300-0341",
                    address = "稲敷郡阿見町うずら野",
                    tel = 5017,
                    staffId = 3,
                    first_action_date = 44702 
                    memo = "メモ3" 
                    input_date = 44672,
                    input_staff_name = "松本尚子"
                    update_date = 44672 
                    update_staff_name = "松本尚子"  
                    delete_flag = false
                },
                new Customer
                {
                    customer_name = "佐賀陽" 
                    customer_kana = "サガヨウ"  
                    companyId = 2
                    section = 製造部
                    post = "課長"  
                    zipcode = "311-2425" 
                    address = "潮来市あやめ"   
                    tel = 5023   
                    staffId = 2  
                    first_action_date = 44632 
                    memo = "メモ2" 
                    input_date = 44602  
                    input_staff_name = "足立美由紀"  
                    update_date = 44602
                    update_staff_name = "足立美由紀" 
                    delete_flag = false
                },
                new Customer
                {
                    customer_name = "本塩遼" 
                    customer_kana = "ホンシオリョウ"
                    companyId = 4 section = QA部
                    post = "主任"  
                    zipcode = "300-0028" 
                    address = "土浦市おおつ野"   
                    tel = 5011    staffId = 1 
                    first_action_date = 44772
                    memo = "メモ4"  
                    input_date = 44742   
                    input_staff_name = "桐生祥秀" 
                    update_date = 44742  
                    update_staff_name = "桐生祥秀"   
                    delete_flag = false
                },

                new Customer
                {
                    customer_name = "谷掛玲子"  
                    customer_kana = "タニガケレイコ" 
                    companyId = 1
                    section = 総務部
                    post = "パート" 
                    zipcode = "319-1417"  
                    address = "日立市かみあい町" 
                    tel = 5005  
                    staffId = 2  
                    first_action_date = 44842
                    memo = "メモ5" 
                    input_date = 44812  
                    input_staff_name = "足立美由紀"  
                    update_date = 44812  
                    update_staff_name = "足立美由紀" 
                    delete_flag = false
                },

                new Customer
                {
                    customer_name = "近藤晃"
                    customer_kana = "コンドウアキラ"
                    companyId = 2
                    section = 設計部 
                    post = "部長"  
                    zipcode = "300-2668"  
                    address = "つくば市かみかわ" 
                    tel = 4999  
                    staffId = 3  
                    first_action_date = 44912 
                    memo = "メモ6" 
                    input_date = 44882   
                    input_staff_name = "松本尚子" 
                    update_date = 44882  
                    update_staff_name = "松本尚子"   
                    delete_flag = false
                },
                new Customer
                {
                    customer_name = "福田美紀"  
                    customer_kana = "フクダミキ" 
                    companyId = 3 
                    section = 製造部
                    post = "課長"  
                    zipcode = "310-0842" 
                    address = "水戸市けやき台"  
                    tel = 4993   
                    staffId = 1  
                    first_action_date = 44252 
                    memo = "メモ7" 
                    input_date = 44952  
                    input_staff_name = "桐生祥秀"
                    update_date = 44952  
                    update_staff_name = "桐生祥秀"  
                    delete_flag = false
                },
                new Customer
                {
                    customer_name = "関口裕太"
                    customer_kana = "セキグチユウタ"
                    companyId = 4
                    section = QA部 
                    post = "担当"  
                    zipcode = "302-0128"  
                    address = "守谷市けやき台"  
                    tel = 4987   
                    staffId = 2   
                    first_action_date = 44322
                    memo = "メモ8" 
                    input_date = 45022  
                    input_staff_name = "足立美由紀"  
                    update_date = 45022 
                    update_staff_name = "足立美由紀"  
                    delete_flag = false
                },
                new Customer
                {
                    customer_name = "鳥内啓子"  
                    customer_kana = "トリウチケイコ" 
                    companyId = 9
                    section = 設計部
                    post = "主任"  
                    zipcode = "306-0055"  
                    address = "古河市けやき平"   
                    tel = 4981   
                    staffId = 3  
                    first_action_date = 44392
                    memo = "メモ9"  input_date =45092   
                    input_staff_name = "松本尚子" 
                    update_date = 45092   
                    update_staff_name = "松本尚子" 
                    delete_flag = false
                },
                new Customer
                {
                    customer_name = "辰巳新" 
                    customer_kana = "タツミアラタ"  
                    companyId = 10    
                    section = 製造部 
                    post = "パート" 
                    zipcode = "306-0308" 
                    address = "猿島郡五霞町ごかみらい"  
                    tel = 4975    staffId = 1   
                    first_action_date = 44462 
                    memo = "メモ10" input_date = 45162  
                    input_staff_name = "桐生祥秀" 
                    update_date = 45162  
                    update_staff_name = "桐生祥秀"   
                    delete_flag = false
                }
            );
            context.SaveChanges();
        }
    }
}