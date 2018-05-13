using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Test
{
    class Program
    {
        public static void Main(String[] args)
        {
            new Menu();
        }

    }
    class Menu
    {
        sql helper;
        public Menu()
        {
            helper = new sql();
            MainMenu();
        }
        //主菜单
        public void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                gotoY(6);
                print("\t\t*****************************************\n");
                print("\t\t+      欢迎来到小型销售部门管理公司     +\n");
                print("\t\t+---------------------------------------+\n");
                print("\t\t+                                       +\n");
                print("\t\t+         1.部门主管                    +\n");
                print("\t\t+                                       +\n");
                print("\t\t+         2.部门职工                    +\n");
                print("\t\t+                                       +\n");
                print("\t\t+         3.退出                        +\n");
                print("\t\t+                                       +\n");
                print("\t\t*****************************************\n");
                print("\n\t\t          请输入您的选项:");
                int Ch = readInt();
                while (Ch == -1)
                {
                    print("\n\t\t          请重新输入选项：");
                    Ch = readInt();
                }
                switch (Ch)
                {
                    case 1:
                        Manager();
                        break;
                    case 2:
                        Employee();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        print("\n\t\t          您的输入有错，请按任意键继续");
                        Console.ReadKey();
                        continue;
                }
            }
        }
        //管理员菜单
        public void Manager()
        {
            while (true)
            {
                Console.Clear();
                gotoY(6);
                print("\t\t*****************************************\n");
                print("\t\t+           部门主管界面                +\n");
                print("\t\t+---------------------------------------+\n");
                print("\t\t+\t 1.管理员工信息\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 2.管理货物信息\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 3.管理销售信息\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 4.返回上层菜单\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 5.退出系统   \t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t*****************************************\n");
                print("\n\t\t\t  请输入您的选项:");
                int Ch = readInt();
                while (Ch == -1)
                {
                    print("\n\t\t\t  请重新输入选项：");
                    Ch = readInt();
                }
                switch (Ch)
                {
                    case 1:
                        ManEmp();
                        break;
                    case 2:
                        ManCargo();
                        break;
                    case 3:
                        ManOrder();
                        break;
                    case 4:
                        return;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        print("\n\t\t          您的输入有错，请按任意键继续");
                        Console.ReadKey();
                        break;
                }
            }
        }
        //管理员-员工管理
        public void ManEmp()
        {
            while (true)
            {
                Console.Clear();
                gotoY(6);
                print("\t\t*****************************************\n");
                print("\t\t+           管理员工信息                +\n");
                print("\t\t+---------------------------------------+\n");
                print("\t\t+\t 1.增加员工信息\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 2.删除员工信息\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 3.查找员工信息\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 4.修改员工信息\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 5.返回上层菜单\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 6.退出系统   \t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t*****************************************\n");
                print("\n\t\t\t  请输入您的选项:");
                int Ch = readInt();
                while (Ch == -1)
                {
                    print("\t\t\t  请重新输入选项：");
                    Ch = readInt();
                }
                switch (Ch)
                {
                    case 1:
                        ManEmp_add();
                        break;
                    case 2:
                        ManEmp_del();
                        break;
                    case 3:
                        ManEmp_find();
                        break;
                    case 4:
                        ManEmp_alter();
                        break;
                    case 5:
                        return;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        print("\n\t\t          您的输入有错，请按任意键继续");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void ManEmp_add()//添加员工
        {
            while (true)
            {
                print_title("员工管理","添加员工");
                print("请按序输入员工的以下信息,每个信息占一行且所有信息均不能为空：\n工号，姓名，性别，年龄，基本工资\n");
                var id = Console.ReadLine();
                var name = Console.ReadLine();
                var sex = Console.ReadLine();
                var age = Console.ReadLine();
                var bas_salary = Console.ReadLine();
                if (check_null(new string[] { id, name, sex, age, bas_salary }))
                {
                    int operatorCode = helper.ManEmp_add(id, name, sex, age, bas_salary);
                    if (operatorCode == 0)
                    {
                        print("添加成功，新增员工后所有员工信息如下：\n");
                        var emps = helper.find_all("employee");
                        print_emp(emps);
                    }
                    else
                    {
                        print_error(operatorCode);
                        Console.ReadKey();
                    }
                }
                else
                {
                    print("\n输入的值中存在某些值为空，请按任意键重新输入：");
                    Console.ReadKey();
                }
                print("\n是否继续添加，继续添加请按【1】，按其他任意键退出添加：");
                int cc = readInt();
                if (cc != 1 || cc == -1)
                {
                    break;
                }
            }
        }
        public void ManEmp_del()//删除员工
        {
            while (true)
            {
                print_title("员工管理","删除员工");
                print("请选择您要删除的员工信息：");
                print("\n【1】删除销售记录为空的员工的记录（开除业绩较差的员工）\n");
                print("\n【2】删除已辞职的员工\n");
                print("\n【3】退出删除\n");
                print("\n请输入您的选项：\n");
                int Ch = readInt();
                while (Ch == -1)
                {
                    print("\n您输入的选项有误，请重新输入选项：");
                    Ch = readInt();
                }
                int operatorCode;
                if (Ch == 1)
                {
                    print_title("员工管理", "删除销售记录为空的员工");
                    operatorCode = helper.ManEmp_del_bad();
                    if (operatorCode == 1)
                    {
                        print("删除失败，要删除的员工不存在\n");
                    }
                    else
                    {
                        print("删除成功，删除后的员工列表如下：\n");
                        var emps = helper.find_all("employee");
                        print_emp(emps);
                    }
                }
                else if (Ch == 2)
                {
                    print("请输入已辞职员工工号：\n");
                    string num = Console.ReadLine();
                    print_title("员工管理", "删除已辞职员工");
                    operatorCode = helper.del_no("employee", "emp_no", num);
                    if (operatorCode == 1)
                    {
                        print("删除失败，要删除的员工不存在\n");
                    }
                    else
                    {
                        print("删除成功，删除后的员工列表如下：\n");
                        var emps = helper.find_all("employee");
                        print_emp(emps);
                    }
                }
                else if (Ch == 3)
                {
                    break;
                }
                else
                {
                    print("\n您输入的选项不存在，按任意键重新输入：");
                    Console.ReadKey();
                    continue;
                }
                print("\n是否继续删除，继续删除请按【1】，按其他任意键退出删除：");
                int cc = readInt();
                if (cc != 1 || cc == -1)
                {
                    break;
                }
            }
        }
        public void ManEmp_find()//查找员工
        {
            while (true)
            {
                print_title("员工管理", "查找员工");
                print("请选择查找条件：\n【1】按照工号查找。\n【2】按员工名字查找（模糊查找，输入部分名字）\n【3】所有员工的信息\n【4】退出查找");
                print("\n请输入:");
                int Ch = readInt();
                while (Ch == -1)
                {
                    print("\n请重新输入选项：");
                    Ch = readInt();
                }
                if (Ch == 1)
                {
                    print("\n请输入要查找的员工的工号：");
                    string id = Console.ReadLine();
                    print_title("员工管理", "按工号查找员工");
                    var emps = helper.find_id("employee", "emp_no", id);
                    print_emp(emps);
                }
                else if (Ch == 2)
                {
                    print("\n请输入员工部分姓名：");
                    string name = Console.ReadLine();
                    print_title("员工管理", "按员工姓名查找员工");
                    var emps = helper.find_name("employee", "emp_name", name);
                    print_emp(emps);
                }
                else if (Ch == 3)
                {
                    var emps = helper.find_all("employee");
                    print_title("员工管理", "查找所有员工");
                    print_emp(emps);
                }
                else if (Ch == 4)
                {
                    break;
                }else
                {
                    print("\n您输入的选项不存在，请按任意键重新输入：");
                    Console.ReadKey();
                    continue;

                }
                print("\n是否继续查找，继续查找请按【1】，按其他任意键退出查找：");
                int cc = readInt();
                if (cc != 1 || cc == -1)
                {
                    break;
                }
            }
        }
        public void ManEmp_alter()//修改员工信息
        {
            while (true)
            {
                print_title("员工管理", "修改员工信息");
                print("所有员工信息如下：\n");
                var emps = helper.find_all("employee");
                print_emp(emps);
                print("\n请输入您要修改信息的员工的工号:");
                var id = Console.ReadLine();
                emps = helper.find_id("employee", "emp_no", id);
                if (emps.Count() == 0)
                {
                    print("\n您输入的员工编号有误，请按任意键继续：");
                    Console.ReadKey();
                    continue;
                }
                print("\n请选择要修改的员工的信息:\n1.姓名    2.性别    3.年龄    4.基本工资    5.退出修改\n");
                print("\n请输入您的选项：");
                int Ch = readInt();
                while (Ch == -1)
                {
                    print("\n请重新输入选项：");
                    Ch = readInt();
                }
                String edit;
                int ty;
                switch (Ch)
                {
                    case 1:
                        print("请输入修改后的员工的姓名：\n");
                        ty = 0;
                        break;
                    case 2:
                        print("请输入修改后的员工的性别：\n");
                        ty = 0;
                        break;
                    case 3:
                        print("请输入修改后的员工的年龄：\n");
                        ty = 1;
                        break;
                    case 4:
                        print("请输入修改后的员工的基本工资：\n");
                        ty = 1;
                        break;
                    case 5:
                        return;
                    default:
                        print("\n您输入的选项不存在，按任意键重新开始修改：");
                        Console.ReadKey();
                        continue;
                }
                edit = Console.ReadLine();
                if ((check_null(new string[] { id })) && (check_null(new string[] { edit }))){
                    helper.ManEmp_alter(id, Ch, edit,ty);
                }
                else if (check_null(new string[] { edit })){
                    print("\n您输入的员工编号为空，请按任意键继续：");
                    Console.ReadKey();
                    continue;
                }
                else if (check_null(new string[] { id }))
                {
                    print("\n您输入的修改后的信息为空，请按任意键继续：");
                    Console.ReadKey();
                    continue;
                }
                print("修改后的信息如下:\n");
                emps = helper.find_id("employee", "emp_no", id);
                print_emp(emps);
                print("\n是否继续修改，继续修改请按【1】，按其他任意键退出修改：");
                int cc = readInt();
                if (cc != 1 || cc == -1)
                {
                    break;
                }
            }
        }
        //管理员-货物管理
        public void ManCargo()
        {
            while (true)
            {
                Console.Clear();
                gotoY(6);
                print("\t\t*****************************************\n");
                print("\t\t+           管理货物信息                +\n");
                print("\t\t+---------------------------------------+\n");
                print("\t\t+\t 1.货物销售情况\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 2.库存过少提示\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 3.返回上层菜单\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 4.退出系统   \t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t*****************************************\n");
                print("\n\t\t\t  请输入您的选项:");
                int Ch = readInt();
                while (Ch == -1)
                {
                    print("\t\t\t  请输入正确选项：");
                    Ch = readInt();
                }
                switch (Ch)
                {
                    case 1:
                        ManCargo_sale();
                        break;
                    case 2:
                        ManCargo_toadd();
                        break;
                    case 3:
                        return;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        print("\n您的输入有错，请按任意键继续");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void ManCargo_sale()
        {
            while (true)
            {
                print_title("管理员","货物管理");
                print("请选择想要查询的货物销售情况：\n");
                print("【1】特定时间段某货物的销售数量\n【2】每位客户最喜欢的货物\n【3】各类货物全部销售完所能带来的盈利\n【4】退出查询\n");
                print("\n请输入您的选项:");
                int Ch = readInt();
                while (Ch == -1)
                {
                    print("请输入正确选项：");
                    Ch = readInt();
                }
                switch (Ch)
                {
                    case 1:
                        ManCargo_sale_time();
                        break;
                    case 2:
                        ManCargo_sale_cust();
                        break;
                    case 3:
                        ManCargo_sale_get();
                        break;
                    case 4:
                        return;
                    default:
                        print("\n您的输入有错，请按任意键继续");
                        Console.ReadKey();
                        break;
                }
                print("\n是否继续货物管理查询，继续查询请按【1】，按其他任意键退出查询：");
                int cc = readInt();
                if (cc != 1 || cc == -1)
                {
                    break;
                }
            }
        }
        public void ManCargo_sale_time()//指定货物指定时间销量
        {
            while (true)
            {
                print_title("货物管理", "特定时间段货物销售情况查询");
                print("\n请输入月份和货物编号，月份和货物销售情况各占一行:\n");
                int mon = readInt();
                while (mon == -1 ||mon>12 ||mon<1)
                {
                    print("请输入正确的月份：");
                    mon = readInt();
                }
                var car_id = Console.ReadLine();
                var sale_times = helper.ManCargo_sale_time(mon, car_id);
                print_sale_time(sale_times);
                print("\n是否继续查询，继续特定时间段货物销售情况查询请按【1】，按其他任意键退出查询：");
                int cc = readInt();
                if (cc != 1 || cc == -1)
                {
                    break;
                }
            }
        }
        public void ManCargo_sale_cust()//每位客户最喜欢的货物查询
        {
            print_title("货物管理", "每位客户最喜欢的货物");
            var sale_custs = helper.ManCargo_sale_cust();
            print_sale_cust(sale_custs);
            print("\n按任意键退出每位客户最喜欢的货物查询：");
            Console.ReadKey();

        }
        public void ManCargo_sale_get()//所有货物全部销售完能得到的盈利
        {
            print_title("货物管理", "各类货物全部销售完所能带来的盈利");
            print("各类货物全部销售完所能带来的盈利为：\n\n");
            var sale_gets = helper.ManCargo_sale_get();
            print_sale_get(sale_gets);
            print("\n按任意键退出各类货物全部销售完所能带来的盈利查询：");
            Console.ReadKey();
        }
        public void ManCargo_toadd()//库存较低的货物
        {
            while (true)
            {
                print_title("货物管理", "查询库存过低的货物");
                print("请输入一个最低库存量:");
                int minp = Int32.Parse(Console.ReadLine());
                var sale_adds = helper.ManCargo_toadd(minp);
                print("\n库存过低货物情况如下：\n\n");
                print_sale_add(sale_adds);
                print("\n是否继续库存过低的货物查询，继续查询请按【1】，按其他任意键退出查询：");
                int cc = readInt();
                if (cc != 1 || cc == -1)
                {
                    break;
                }
            }
        }

        //管理员-销售管理
        public void ManOrder()
        {
            while (true)
            {
                Console.Clear();
                gotoY(6);
                print("\t\t*****************************************\n");
                print("\t\t+           管理销售信息                +\n");
                print("\t\t+---------------------------------------+\n");
                print("\t\t+\t 1.查询金额最大的订单\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 2.查询指定月份的盈利\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 3.查询员工提成及工资\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 4.返回上层菜单\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 5.退出系统   \t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t*****************************************\n");
                print("\n\t\t\t  请输入您的选项:");
                int Ch = readInt();
                while (Ch == -1)
                {
                    print("\t\t\t  请输入正确选项：");
                    Ch = readInt();
                }
                switch (Ch)
                {
                    case 1:
                        ManOrder_max();
                        break;
                    case 2:
                        ManOrder_get();
                        break;
                    case 3:
                        ManOrder_empsal();
                        break;
                    case 4:
                        return;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        print("\n\t\t\t  您的输入有错，请按任意键继续");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void ManOrder_max()//金额最大的订单查询
        {
            print_title("管理销售信息", "查询金额最大的订单");
            var sale_maxs = helper.ManOrder_max();
            print("金额最大的订单情况如下：\n\n");
            print_sale_max(sale_maxs);
            print("\n按任意键退出金额最大的订单查询：");
            Console.ReadKey();
        }
        public void ManOrder_get()//指定月份的盈利
        {
            while (true)
            {
                print_title("管理销售信息", "查询指定月份的盈利");
                print("请输入月份：\n");
                int mon = readInt();
                while (mon == -1 || mon > 12 || mon < 1)
                {
                    print("请输入正确的月份：");
                    mon = readInt();
                }
                var orders_gets = helper.ManOrder_get(mon);
                print("该月份的盈利情况如下：\n\n");
                print_order_get(orders_gets);
                print("\n是否继续查询，继续查询请按【1】，按其他任意键退出查询：");
                int cc = readInt();
                if (cc != 1)
                {
                    break;
                }
            }
        }
        public void ManOrder_empsal()//员工某月提成及工资查询
        {
            while (true)
            {
                print_title("管理销售信息", "查询员工提成及工资");
                print("请输入员工编号、月份以及提成率：每个信息占一行且所有信息均不能为空：\n");
                print("请输入员工编号：");
                var emp_id = Console.ReadLine();
                while (check_null(new string[] { emp_id })==false){
                    print("\n输入的员工编号不合法，请重新输入：");
                    emp_id = Console.ReadLine();
                }
                print("\n请输入月份：");
                int mon = readInt();
                while (mon == -1 || mon > 12 || mon < 1)
                {
                    print("\n请输入正确的月份：");
                    mon = readInt();
                }
                print("\n请输入提成率：");
                float dedu = readFloat();
                while (dedu == -1 || dedu < 0)
                {
                    print("\n请输入正确的提成率：");
                    dedu = readFloat();
                }
                var empsals = helper.ManOrder_empsal(emp_id, mon, dedu);
                print("\n员工提成及工资情况如下：\n\n");
                print_empsal(empsals);
                print("\n是否继续查询，继续查询请按【1】，按其他任意键退出查询：\n");
                int cc = readInt();
                if (cc != 1)
                {
                    break;
                }
            }

        }

        //员工界面
        public void Employee()
        {
            while (true)
            {
                Console.Clear();
                gotoY(6);
                print("\t\t*****************************************\n");
                print("\t\t+           部门职员界面                +\n");
                print("\t\t+---------------------------------------+\n");
                print("\t\t+\t   1.货物管理\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t   2.订单管理\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t   3.添加客户\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t   4.返回上层菜单\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t   5.退出系统   \t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t*****************************************\n");
                print("\n\t\t\t  请输入您的选项:");
                int Ch = readInt();
                while (Ch == -1)
                {
                    print("\n\t\t\t  请输入正确选项：");
                    Ch = readInt();
                }
                switch (Ch)
                {
                    case 1:
                        EmpCargo();
                        break;
                    case 2:
                        EmpOrder();
                        break;
                    case 3:
                        EmpCust_add();
                        break;
                    case 4:
                        return;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        print("\n\t\t\t  您的输入有错，请按任意键继续");
                        Console.ReadKey();
                        break;
                }
            }
        }
        //员工-货物管理
        public void EmpCargo()
        {
            while (true)
            {
                Console.Clear();
                gotoY(6);
                print("\t\t*****************************************\n");
                print("\t\t+           管理货物信息                +\n");
                print("\t\t+---------------------------------------+\n");
                print("\t\t+\t 1.增加货物信息\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 2.删除货物信息\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 3.查找货物信息\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 4.修改货物信息\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 5.返回上层菜单\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 6.退出系统   \t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t*****************************************\n");
                print("\n\t\t\t  请输入您的选项:");
                int Ch = readInt();
                while (Ch == -1)
                {
                    print("\n\t\t\t  请重新输入选项：");
                    Ch = readInt();
                }
                switch (Ch)
                {
                    case 1:
                        EmpCargo_add();
                        break;
                    case 2:
                        EmpCargo_del();
                        break;
                    case 3:
                        EmpCargo_find();
                        break;
                    case 4:
                        EmpCargo_alter();
                        break;
                    case 5:
                        return;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        print("\n\t\t\t  您的输入有错，请按任意键继续");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void EmpCargo_add()
        {
            while (true)
            {
                print_title("货物管理", "增加货物");
                print("请按序输入货物的以下信息,且每个信息占一行：\n编号，名称，进价，售价，库存量\n");
                var cargo_no = Console.ReadLine();
                var name = Console.ReadLine();
                var pur_price = Console.ReadLine();
                var sale_price = Console.ReadLine();
                var inventory = Console.ReadLine();
                if (check_null(new string[] { cargo_no, name, pur_price, sale_price, inventory }))
                {
                    int operatorCode = helper.Cargo_add(cargo_no, name, pur_price, sale_price, inventory);
                    if (operatorCode == 0)
                    {
                        print("添加成功，新增货物后所有货物信息如下：\n\n");
                        var cars = helper.find_all("cargo");
                        print_car(cars);
                    }
                    else
                    {
                        print_error(operatorCode);
                        Console.ReadKey();
                    }
                }
                else
                {
                    print("\n输入的值中存在某些值为空，请按任意键重新输入：");
                    Console.ReadKey();
                }
                print("\n是否继续添加，继续添加请按【1】，按其他任意键退出添加：");
                int cc = readInt();
                if (cc != 1 || cc == -1)
                {
                    break;
                }
            }
        }
        public void EmpCargo_del()
        {
            while (true)
            {
                print_title("货物管理", "删除货物");
                print("所有货物信息如下\n");
                var cars = helper.find_all("cargo");
                print_car(cars);
                int operatorCode;
                print("请输入要删除的货物编号：\n");
                string num = Console.ReadLine();
                operatorCode = helper.del_no("cargo", "car_no", num);
                if (operatorCode == 1)
                {
                    print("删除失败，要删除的货物不存在\n");
                }
                else
                {
                    print("删除成功，删除后的货物列表如下：\n");
                    cars = helper.find_all("cargo");
                    print_car(cars);
                }
                print("\n是否继续删除，继续删除请按【1】，按其他任意键退出删除：");
                int cc = readInt();
                if (cc != 1 || cc == -1)
                {
                    break;
                }
            }
        }
        public void EmpCargo_find()
        {
            while (true)
            {
                print_title("货物管理", "查找货物");
                print("请选择查找条件：\n【1】按照货号查找。\n【2】按货物名字查找（模糊查找，输入部分名字）\n【3】所有货物的信息\n【4】退出查找");
                print("\n请输入:");
                int Ch = readInt();
                while (Ch == -1)
                {
                    print("\n请重新输入选项：");
                    Ch = readInt();
                }
                if (Ch == 1)
                {
                    print("\n请输入要查找的货物的编号：");
                    string id = Console.ReadLine();
                    print_title("货物管理", "按货号查找货物");
                    var cars = helper.find_id("cargo", "car_no", id);
                    print_car(cars);
                }
                else if (Ch == 2)
                {
                    print("\n请输入货物部分名称：");
                    string name = Console.ReadLine();
                    print_title("货物", "按货物名称查找货物");
                    var cars = helper.find_name("cargo", "car_name", name);
                    print_car(cars);
                }
                else if (Ch == 3)
                {
                    var cars = helper.find_all("cargo");
                    print_title("货物管理", "查找所有货物");
                    print_car(cars);
                }
                else if (Ch == 4)
                {
                    break;
                }
                else
                {
                    print("\n您输入的选项不存在，请按任意键重新输入：");
                    Console.ReadKey();
                    continue;

                }
                print("\n是否继续查找，继续查找请按【1】，按其他任意键退出查找：");
                int cc = readInt();
                if (cc != 1 || cc == -1)
                {
                    break;
                }
            }
        }
        public void EmpCargo_alter()
        {
            while (true)
            {
                print_title("货物管理", "修改货物信息");
                print("所有货物信息如下：\n");
                var cars = helper.find_all("cargo");
                print_car(cars);
                print("\n请输入您要修改信息的货物的编号:");
                var id = Console.ReadLine();
                cars = helper.find_id("cargo", "car_no", id);
                if (cars.Count() == 0)
                {
                    print("\n您输入的货物编号有误，请按任意键继续：");
                    Console.ReadKey();
                    continue;
                }
                print("请选择要修改的员工的信息:\n1.名称\t2.进价\t3.售价\t4.库存量\t5.退出修改\n");
                print("\n请输入您的选项：");
                int Ch = readInt();
                while (Ch == -1)
                {
                    print("\n请重新输入选项：");
                    Ch = readInt();
                }
                String edit;
                int ty;
                switch (Ch)
                {
                    case 1:
                        print("\n请输入修改后的货物的名称：");
                        ty = 0;
                        break;
                    case 2:
                        print("\n请输入修改后的货物的进价：");
                        ty = 1;
                        break;
                    case 3:
                        print("\n请输入修改后的货物的售价：");
                        ty = 1;
                        break;
                    case 4:
                        print("\n请输入修改后的货物的库存量：");
                        ty = 1;
                        break;
                    case 5:
                        return;
                    default:
                        print("\n您输入的选项不存在，按任意键重新开始修改：");
                        Console.ReadKey();
                        continue;
                }
                edit = Console.ReadLine();
                if ((check_null(new string[] { id })) && (check_null(new string[] { edit })))
                {
                    helper.Cargo_alter(id, Ch, edit,ty);
                }
                else if (check_null(new string[] { edit }))
                {
                    print("\n您输入的货物编号为空，请按任意键继续：");
                    Console.ReadKey();
                    continue;
                }
                else if (check_null(new string[] { id }))
                {
                    print("\n您输入的修改后的信息为空，请按任意键继续：");
                    Console.ReadKey();
                    continue;
                }
                print("修改后的信息如下:\n");
                cars = helper.find_id("cargo", "car_no", id);
                print_car(cars);
                print("\n是否继续修改，继续修改请按【1】，按其他任意键退出修改：");
                int cc = readInt();
                if (cc != 1 || cc == -1)
                {
                    break;
                }
            }
        }
        //员工-订单管理
        public void EmpOrder()
        {
            while (true)
            {
                Console.Clear();
                gotoY(6);
                print("\t\t*****************************************\n");
                print("\t\t+           管理订单信息                +\n");
                print("\t\t+---------------------------------------+\n");
                print("\t\t+\t 1.增加订单信息\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 2.查找订单信息\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 3.修改订单信息\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 4.返回上层菜单\t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t+\t 5.退出系统   \t\t\t+\n");
                print("\t\t+\t              \t\t\t+\n");
                print("\t\t*****************************************\n");
                print("\n\t\t\t  请输入您的选项:");
                int Ch = readInt();
                while (Ch == -1)
                {
                    print("\n\t\t\t  请重新输入选项：");
                    Ch = readInt();
                }
                switch (Ch)
                {
                    case 1:
                        EmpOrder_add();
                        break;
                    case 2:
                        ManOrder_find();
                        break;
                    case 3:
                        ManOrder_alter();
                        break;
                    case 4:
                        return;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        print("\n\t\t          您的输入有错，请按任意键继续");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void EmpOrder_add()
        {
            while (true)
            {
                print_title("订单管理", "增加订单信息");
                print("请按顺序输入订单的以下信息，且每个信息占一行：\n订单号，销售日期，货物编号，客户编号，销售员编号，销售数量\n日期用-隔开。如（2016-03-15）\n");
                var order_no = Console.ReadLine();
                var order_time = Console.ReadLine();
                var cargo_no = Console.ReadLine();
                var cus_no = Console.ReadLine();
                var emp_no = Console.ReadLine();
                var qty = Console.ReadLine();
                if (check_null(new string[] { order_no, order_time, cargo_no, cus_no, emp_no, qty }))
                {
                    int operatorCode = helper.Order_add(order_no, order_time, cargo_no, cus_no, emp_no, qty);
                    if (operatorCode == 0)
                    {
                        print("添加成功，新增订单后所有订单信息如下：\n");
                        var sales = helper.find_all("sale_item");
                        print_sale(sales);
                    }
                    else
                    {
                        print_error(operatorCode);
                        Console.ReadKey();
                    }
                }
                else
                {
                    print("\n输入的值中存在某些值为空，请按任意键重新输入：");
                    Console.ReadKey();
                }
                print("\n是否继续添加，继续添加请按【1】，按其他任意键退出添加：");
                int cc = readInt();
                if (cc != 1 || cc == -1)
                {
                    break;
                }

            }
        }
        public void ManOrder_find()
        {
            while (true)
            {
                print_title("订单管理", "订单查询");
                print("请输入查找方法：\n【1】订单号查找\n【2】查找所有订单\n【3】退出查询\n");
                print("\n请输入:");
                int Ch = readInt();
                while (Ch == -1)
                {
                    print("\n请重新输入选项：");
                    Ch = readInt();
                }
                if (Ch == 1)
                {
                    print("\n请输入要查找的订单号的编号：");
                    string id = Console.ReadLine();
                    print_title("订单管理", "按订单号查找货物");
                    var sales = helper.find_id("sale_item", "sale_no", id);
                    print_sale(sales);
                }
                else if (Ch == 2)
                {
                    var sales = helper.find_all("sale_item");
                    print_title("订单管理", "查找所有订单");
                    print_sale(sales);
                }
                else if (Ch == 3)
                {
                    break;
                }
                else
                {
                    print("\n您输入的选项不存在，请按任意键重新输入：");
                    Console.ReadKey();
                    continue;

                }
                print("\n是否继续查找，继续查找请按【1】，按其他任意键退出查找：");
                int cc = readInt();
                if (cc != 1 || cc == -1)
                {
                    break;
                }
            }
        }
        public void ManOrder_alter()
        {
            while (true)
            {
                print_title("货物管理", "修改货物信息");
                print("所有订单信息如下：\n");
                var sales = helper.find_all("sale_item");
                print_sale(sales);
                print("\n请输入您要修改信息的订单的编号:");
                var id = Console.ReadLine();
                sales = helper.find_id("sale_item", "sale_no", id);
                if (sales.Count() == 0)
                {
                    print("\n您输入的订单编号有误，请按任意键继续：");
                    Console.ReadKey();
                    continue;
                }
                print("请选择要修改的订单的信息:\n【1】销售日期\t【2】货物编号\t【3】销售员编号\t【4】销售数量\t【5】退出修改\n");
                print("\n请输入您的选项：");
                int Ch = readInt();
                while (Ch == -1)
                {
                    print("\n请重新输入选项：");
                    Ch = readInt();
                }
                String edit;
                int ty;
                switch (Ch)
                {
                    case 1:
                        print_title("修改订单", "销售日期");
                        print("请输入修改后的销售日期，用-隔开。（2016-03-15）：\n");
                        ty = 0;
                        break;
                    case 2:
                        print_title("修改订单", "货物编号");
                        print("请输入修改后的货物编号：\n");
                        ty = 0;
                        break;
                    case 3:
                        print_title("修改订单", "销售员编号");
                        print("请输入修改后的销售员编号：\n");
                        ty = 0;
                        break;
                    case 4:
                        print_title("修改订单", "销售数量");
                        print("请输入修改后的销售数量：\n");
                        ty = 1;
                        break;
                    case 5:
                        return;
                    default:
                        print("\n您输入的选项不存在，按任意键重新开始修改：");
                        Console.ReadKey();
                        continue;
                }
                edit = Console.ReadLine();
                if ((check_null(new string[] { id })) && (check_null(new string[] { edit })))
                {
                    helper.ManOrder_alter(id, Ch, edit,ty);
                }
                else if (check_null(new string[] { edit }))
                {
                    print("\n您输入的订单编号为空，请按任意键继续：");
                    Console.ReadKey();
                    continue;
                }
                else if (check_null(new string[] { id }))
                {
                    print("\n您输入的修改后的信息为空，请按任意键继续：");
                    Console.ReadKey();
                    continue;
                }
                print("修改后的信息如下:\n");
                sales = helper.find_id("sale_item", "sale_no", id);
                print_sale(sales);
                print("\n是否继续修改，继续修改请按【1】，按其他任意键退出修改：");
                int cc = readInt();
                if (cc != 1 || cc == -1)
                {
                    break;
                }
            }
        }
        //添加客户
        public void EmpCust_add()
        {
            while (true)
            {
                while (true)
                {
                    print_title("销售员", "添加客户");
                    print("请按序输入客户的以下信息,且每个信息占一行：\n编号，姓名，电话，住址\n");
                    var cust_no = Console.ReadLine();
                    var name = Console.ReadLine();
                    var tel = Console.ReadLine();
                    var addr = Console.ReadLine();
                    if (check_null(new string[] { cust_no, name, tel, addr }))
                    {
                        int operatorCode = helper.Cust_add(cust_no, name, tel, addr);
                        if (operatorCode == 0)
                        {
                            print("添加成功，新增客户后所有客户信息如下：\n");
                            var custs = helper.find_all("customer");
                            print_cust(custs);
                        }
                        else
                        {
                            print_error(operatorCode);
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        print("\n输入的值中存在某些值为空，请按任意键重新输入：");
                        Console.ReadKey();
                    }
                    print("\n是否继续添加，继续添加请按【1】，按其他任意键退出添加：");
                    int cc = readInt();
                    if (cc != 1 || cc == -1)
                    {
                        break;
                    }
                }
            }
        }

        //打印及附属函数
        public int readInt()
        {
            int Ch;
            try
            {
                Ch = Int32.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                
                    return -1;
            }
            return Ch;
        }
        public float readFloat()
        {
            float x;
            try
            {
                x = float.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {

                return -1;
            }
            return x;
        }
        public bool check_null(string[] s)
        {
            foreach (var i in s)
            {
                if (i == null || i.Length == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public void gotoY(int y)
        {
            for (int i = 0; i < y; i++)
            {
                print("\n");
            }
        }
        public void print(string s)
        {
            Console.Write(s);
        }
        public void print_title(string s1, string s2)
        {
            Console.Clear();
            gotoY(2);
            print(s1);
            print("--->");
            print(s2);
            print("\n————————————————————————————————\n");
        }
        public void print_emp(DataRow[] emps)
        {
            if (emps.Count() == 0)
            {
                print("没有您要的信息");
            }
            else
            {
                print("工号\t\t姓名\t\t性别\t年龄\t\t基本工资\n");
                foreach (var r in emps)
                {
                    print(r["emp_no"].ToString() + "\t" + r["emp_name"].ToString() + "\t" + r["sex"].ToString() + "\t" + r["age"].ToString() + "\t" + "\t" + r["bas_salary"].ToString() + "\n");
                }
            }
        }
        public void print_car(DataRow[] cars)
        {
            if (cars.Count() == 0)
            {
                print("没有您要的信息");
            }
            else
            {
                print("货号\t\t名称\t进价\t售价\t库存量\n");
                foreach (var r in cars)
                {
                    print(r["car_no"].ToString() + "\t" + r["car_name"].ToString().Trim() + "\t" + r["pur_price"].ToString() + "\t" + r["sale_price"].ToString() + "\t" + r["inventory"].ToString() + "\n");
                }
            }
        }
        public void print_cust(DataRow[] custs)
        {
            if (custs.Count() == 0)
            {
                print("没有您要的信息");
            }
            else
            {
                print("客户编号\t姓名\t电话号码\t住址\t\n");
                foreach (var r in custs)
                {
                    print(r["cus_no"].ToString() + "\t" + r["cus_name"].ToString() + "\t" + r["tel"].ToString() + "\t" + r["addr"].ToString() + "\n");
                }
            }
        }
        public void print_sale(DataRow[] sales)
        {
            if (sales.Count() == 0)
            {
                print("没有您要的信息");
            }
            else
            {
                print("订单号\t\t销售日期\t\t货物编号\t客户编号\t销售员\t销售数量\n");
                foreach (var r in sales)
                {
                    print(r["sale_no"].ToString() + "\t" + r["sale_date"].ToString() + "\t" + r["car_no"].ToString() + "\t" + r["cus_no"].ToString() + "\t" + r["emp_no"].ToString().Trim() + "\t" + r["qty"].ToString() + "\n");
                }
            }
        }
        public void print_sale_time(DataRow[] sale_times)
        {
            if (sale_times.Count() == 0)
            {
                print("没有您要的信息");
            }
            else
            {


                print("货物编号\t货物名称\t销售数量\n");
                foreach (var r in sale_times)
                {
                    print(r["car_no"].ToString() + "\t" + r["car_name"].ToString()  + r["销售数量"].ToString() + "\n");
                }
            }
        }
        public void print_sale_cust(DataRow[] sale_custs)
        {
            if (sale_custs.Count() == 0)
            {
                print("没有您要的信息");
            }
            else
            {
                print("客户名称\t最喜欢的货物\t购买数量\n");
                foreach (var r in sale_custs)
                {
                    print(r["cus_no"].ToString() + "\t" + r["cus_name"].ToString() + "\t" + r["最大值"].ToString() + "\n");
                }
            }
        }
        public void print_sale_get(DataRow[] sale_gets)
        {
            if (sale_gets.Count() == 0)
            {
                print("没有您要的信息");
            }
            else
            {
                print("货物名称\t    盈利\n");
                foreach (var r in sale_gets)
                {
                    print(r["car_name"].ToString()  + r["盈利"].ToString() + "\n");
                }
            }
        }
        public void print_sale_add(DataRow[] sale_adds)
        {
            if (sale_adds.Count() == 0)
            {
                print("没有您要的信息");
            }
            else
            {
                print("货物名称\t  剩余数量\n");
                foreach (var r in sale_adds)
                {
                    print(r["car_name"].ToString() + r["inventory"].ToString() + "\n");
                }
            }
        }
        public void print_sale_max(DataRow[] sale_maxs)
        {
            if (sale_maxs.Count() == 0)
            {
                print("没有您要的信息");
            }
            else
            {
                print("订单号\t\t订单日期\t\t货物名称\t客户名称\t售货员编号\t数量\t订单金额\n");
                foreach (var r in sale_maxs)
                {
                    print(r["sale_no"].ToString() + "\t" + r["sale_date"].ToString() + "\t" + r["car_name"].ToString().Trim() + "\t\t" + r["cus_no"].ToString() + "\t" + r["emp_no"].ToString() + "\t" + r["qty"].ToString() + "\t" + r["订单金额"].ToString() + "\n");
                }
            }
        }
        public void print_order_get(DataRow[] orders_gets)
        {
            if (orders_gets.Count() == 0)
            {
                print("没有您要的信息");
            }
            else
            {
                print("月份\t盈利\n");
                foreach (var r in orders_gets)
                {
                    print(r["月份"].ToString() + "\t" + r["盈利"].ToString() + "\n");
                }
            }
        }
        public void print_empsal(DataRow[] empsals)
        {
            if (empsals.Count() == 0)
            {
                print("没有您要的信息");
            }
            else
            {
                print("员工编号\t员工姓名\t月份\t提成\t工资\n");
                foreach (var r in empsals)
                {
                    print(r["员工"].ToString() + "\t" + r["姓名"].ToString() + "\t" + r["月份"].ToString() + "\t" + r["提成"].ToString() + "\t" + r["工资"].ToString() + "\n");
                }
            }
        }
        public void print_error(int operatorCode)
        {
            if (operatorCode == 2)
            {
                print("\n主码已存在，请按任意键重新输入:");
            }
            else if (operatorCode == 3)
            {
                print("\n主码不能为空，请按任意键重新输入:");
            }
            else if (operatorCode == 4)
            {
                print("\n输入中存在某些值不符合约束，请按任意键重新输入：");
            }
            else if (operatorCode == 5)
            {
                print("\n列名或所提供值的数目与表定义不匹配，请按任意键重新输入：");
            }
            else if (operatorCode == 6)
            {
                print("\n插入数据时有语法错误，请按任意键重新输入:");
            }
            else if(operatorCode == 7)
            {
                print("\n插入的数据中有非法值，请按任意键重新输入:");
            }
            else if(operatorCode == 8)
            {
                print("\n插入的数据中时间不合法，请按任意键重新输入:");
            }
            else if (operatorCode == 1)
            {
                print("\n没有任何行受影响，请按任意键重新输入：");
            }
        }
    }

    class sql
    {
        private SqlConnection connection;
        public sql()
        {
            initSqlConnection();
        }
        private void initSqlConnection()
        {

            connection = new SqlConnection();

            String SqlIP = "127.0.0.1";//本地SQL服务器地址

            String InstanceName = "SQLEXPRESS";//SQL实例名

            String DateBaseName = "Test";//数据库名称

            String UserName = "MuYi41";//登录用户名

            String PassWord = "970814";//登录密码

            //写入连接所使用的字符串信息

            connection.ConnectionString = String.Format("server = {0}\\{1}; database = {2}; uid = {3}; pwd = {4}", SqlIP, InstanceName, DateBaseName, UserName, PassWord);
            //Console.WriteLine(connection.ConnectionString);


        }

        //增加
        public int ManEmp_add(string id, string name, string sex, string age, string bas_salary)
        {
            String insertSql = String.Format("INSERT INTO employee VALUES ('{0}', '{1}','{2}',{3},{4})", id, name, sex, age, bas_salary );
            return ExecuteNonQuery(insertSql);
        }
        public int Cargo_add(string cargo_no, string name, string pur_price, string sale_price, string inventory)
        {
            String insertSql = String.Format("INSERT INTO cargo VALUES ('{0}', '{1}',{2},{3},{4})", cargo_no, name, pur_price, sale_price, inventory);
            SqlCommand cmd = new SqlCommand(insertSql, connection);
            return ExecuteNonQuery(insertSql);
        }
        public int Order_add(string order_no, string order_time, string cargo_no, string cus_no, string emp_no, string qty)
        {

            String insertSql = $"INSERT INTO sale_item VALUES('{order_no}', '{order_time}', '{cargo_no}', '{cus_no}','{emp_no}', {qty})";
            return ExecuteNonQuery(insertSql);
        }
        public int Cust_add(string cust_no, string cust_name, string tel, string addr)
        {

            String insertSql = $"INSERT INTO customer VALUES('{cust_no }', '{cust_name}','{tel}','{addr}')";
            return ExecuteNonQuery(insertSql);
        }

        //删除
        public int ManEmp_del_bad()
        {
            String deleteSql = String.Format("DELETE FROM employee WHERE emp_no NOT IN (SELECT emp_no FROM sale_item)");
            return ExecuteNonQuery(deleteSql);
        }
        public int del_no(string s, string sn, string num)
        {
            String deleteSql = $"DELETE FROM {s} WHERE {sn} LIKE '{num}'";
            return ExecuteNonQuery(deleteSql);
        }

        //查找
        public DataRow[] find_all(string s)
        {
            String querySql = $"SELECT * FROM {s}";
            return ExecutQuery(querySql);
        }
        public DataRow[] find_id(string s, string sn, string id)
        {
            String querySql = $"SELECT * FROM {s} WHERE {sn} LIKE '{id}'";
            return ExecutQuery(querySql);
        }
        public DataRow[] find_name(string s, string sn, string name)
        {
            StringBuilder bu = new StringBuilder();
            bu.Append("%");
            foreach (var c in name)
            {
                if (c == ' ')
                {
                    continue;
                }
                bu.Append(c);
                bu.Append("%");
            }
            name = bu.ToString();
            String querySql = $"SELECT * FROM {s} WHERE {sn} LIKE '{name}'";
            return ExecutQuery(querySql);
        }
        public DataRow[] ManCargo_sale_time(int mon, string car_id)
        {
            string querySaleTimeSql = $"select cargo.car_no,car_name,sum(qty) 销售数量 from cargo, sale_item where cargo.car_no = sale_item.car_no and sale_item.car_no = '{car_id}' and month(sale_date) = {mon} group by cargo.car_no,car_name,month(sale_date)";
            return ExecutQuery(querySaleTimeSql);
        }
        public DataRow[] ManCargo_sale_cust()
        {
            string querySaleCust = $"select cus_no,cus_name,car_name,最大值 from (select C.cus_no 客, D.car_no 货, C.最大值 from(select B.cus_no, max(B.总数量) 最大值 from (select cus_no, car_no, sum(qty) 总数量 from sale_item group by cus_no, car_no) B group by B.cus_no) C, (select cus_no, car_no, sum(qty) 总数量 from sale_item group by cus_no, car_no) D where D.总数量 = C.最大值 and D.cus_no = C.cus_no and D.car_no = D.car_no)E,cargo,customer where cargo.car_no = E.货 and customer.cus_no = E.客";
            return ExecutQuery(querySaleCust);
        }
        public DataRow[] ManCargo_sale_get()
        {
            string querySaleGet = $"select car_name,inventory*(sale_price - pur_price) 盈利 from cargo order by 盈利 DESC";
            return ExecutQuery(querySaleGet);
        }
        public DataRow[] ManCargo_toadd(int minp)
        {
            string queryToAdd = $"select car_name,inventory from cargo where inventory < {minp} order by inventory";
            return ExecutQuery(queryToAdd);
        }
        public DataRow[] ManOrder_max()
        {
            string quertMax = $"select sale_no,sale_date,cargo.car_name,cus_no,emp_no,qty,qty*(sale_price-pur_price) 订单金额 from sale_item,cargo where cargo.car_no = sale_item.car_no and qty*(sale_price-pur_price) = (select max(qty*(sale_price-pur_price)) 最大金额 from sale_item,cargo where cargo.car_no = sale_item.car_no)";
            return ExecutQuery(quertMax);
        }
        public DataRow[] ManOrder_get(int mon)
        {
            string queryOrderGet = $"select month(sale_date) 月份,sum(qty * (sale_price - pur_price)) 盈利 from sale_item,cargo where cargo.car_no = sale_item.car_no and month(sale_date) = 3 group by month(sale_date)";
            return ExecutQuery(queryOrderGet);
        }
        public DataRow[] ManOrder_empsal(string emp_id, int mon, float dedu)
        {
            string queryEmpsal = $"select employee.emp_no 员工, emp_name 姓名,month(sale_date) 月份,sum(qty * (sale_price - pur_price) * {dedu}) 提成,(bas_salary + sum(qty * (sale_price - pur_price) * {dedu})) 工资 from employee,cargo,sale_item where employee.emp_no = sale_item.emp_no and cargo.car_no = sale_item.car_no and MONTH(sale_date) = {mon} and employee.emp_no = '{emp_id}' group by employee.emp_no,emp_name,month(sale_date),bas_salary";
            return ExecutQuery(queryEmpsal);
        }

        //修改
        public void ManEmp_alter(string id, int Ch, string edit,int ty)
        {
            if (ty == 0)
                edit = $"'{edit}'";
            String[] na = new string[] { "emp_name", "sex", "age", "tot_amt", "bas_salary" };
            String alterSql = $"UPDATE employee SET {na[Ch - 1]} = '{edit}' WHERE emp_no = '{id}'";
            ExecuteNonQuery(alterSql);
        }
        public void Cargo_alter(string id, int Ch, string edit,int ty)
        {
            if (ty == 0)
                edit = $"'{edit}'";
            String[] na = new string[] { "car_name", "pur_price", "sale_price", "tot_amt", "inventory" };
            String alterSql = $"UPDATE cargo SET {na[Ch - 1]} = {edit} WHERE car_no = '{id}'";
            ExecuteNonQuery(alterSql);
        }
        public void ManOrder_alter(string id, int Ch, string edit,int ty)
        {
            if (ty == 0)
                edit = $"'{edit}'";
            String[] na = new string[] { "sale_date", "car_no", "cus_no", "emp_no", "qty" };
            String alterSql = $"UPDATE sale_item SET {na[Ch - 1]} = {edit} WHERE sale_no = '{id}'";
            ExecuteNonQuery(alterSql);
        }
        
        private DataRow[] ExecutQuery(string s)
        {
            connection.Open();
            //构造一个接收数据的容器
            DataTable dt = new DataTable();
            //构造一个数据适配器
            SqlDataAdapter adapter = new SqlDataAdapter(s, connection);
            //发起查询，并把数据填充到dt中
            adapter.Fill(dt);
            //dt是一个结果集，本身不能去遍历它，我们通过Select方法取出行的数组
            DataRow[] data = dt.Select();
            connection.Close();
            return data;
        }
        private int ExecuteNonQuery(string s)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(s, connection);
            int delLen = 0;
            int operatorCode = 0;
            try
            {
                delLen = cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                if (e.Number == 2627)//主码已存在
                {
                    operatorCode = 2;
                }
                if (e.Number == 515)//主码为空
                {
                    operatorCode = 3;
                }
                if (e.Number == 547)//不符合约束
                {
                    operatorCode = 4;
                }
                if (e.Number == 213)//列名或所提供值的数目与表定义不匹配
                {
                    operatorCode = 5;
                }
                if (e.Number == 102)//插入数据时有语法错误。
                {
                    operatorCode = 6;
                }
                if (e.Number == 207)//输入的值非法
                { 
                    operatorCode = 7;
                }
                if (e.Number == 242)//输入的时间不合法
                {
                    operatorCode = 8;
                }
            }
            connection.Close();
            if (operatorCode == 0 && delLen == 0)//受影响行数为0
            {
                operatorCode = 1;
            }
            return operatorCode;
        }
    }
}


