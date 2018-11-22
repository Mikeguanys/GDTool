using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace GDateBase2v.GDTools
{
    public static class GDORMProcess
    {
        #region 处理入口
        /// <summary>
        /// 主处理
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public static string DealExpress(this Expression exp, string symbol = null)
        {
            if (exp == null)
            {
                return "";
            }
            if (exp.NodeType == ExpressionType.Not)
            {
                symbol = "!";
            }
            //描述一个lambda表达式
            if (exp is LambdaExpression)
            {
                LambdaExpression l_exp = exp as LambdaExpression;
                return DealExpress(l_exp.Body);
            }
            //表示包含二次元运算符的表达式
            else if (exp is BinaryExpression)
            {
                return DealBinaryExpression(exp as BinaryExpression);
            }
            //表示访问字段或属性
            else if (exp is MemberExpression)
            {
                return DealMemberExpression(exp as MemberExpression);
            }
            //表示包含条件运算符的表达式
            else if (exp is ConstantExpression)
            {
                return DealConstantExpression(exp as ConstantExpression);
            }
            //表示包含一元运输符的表达式
            else if (exp is UnaryExpression)
            {
                return DealUnaryExpression(exp as UnaryExpression, symbol);
            }
            //表示将委托或lambda表达式应用与参数表达式列表的表达式
            else if (exp is InvocationExpression)
            {
                return "";
            }
            //表示调用一种方法
            else if (exp is MethodCallExpression)
            {
                string strexp = "";
                ProcessMethod(exp as MethodCallExpression, ref strexp, symbol);
                return strexp;
            }
            //表示创建数组并可能初始化该新数组
            else if (exp is NewArrayExpression)
            {
                var ArrayExp = exp as NewArrayExpression;
                string val = "(";
                foreach (var item in ArrayExp.Expressions)
                {
                    val += item.DealExpress() + ",";
                }
                return val.TrimEnd(',') + ")";
            }
            //表示构造函数调用
            else if (exp is NewExpression)
            {
                var e = (exp as NewExpression).Members;
                string[] names = new string[e.Count];
                for (int i = 0; i < e.Count; i++)
                {
                    names[i] = e[i].Name;
                }
                return string.Join(",", names);
            }
            //表示命名的参数表达式
            else if (exp is ParameterExpression)
            {
                return "";
            }
            //表示表达式和类型之间的操作
            else if (exp is TypeBinaryExpression)
            {
                return "";
            }
            else
            {
                return "";
            }

        }
        #endregion
        #region 处理各个方法
        /// <summary>
        /// 二次元运算符的表达式
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        private static string DealBinaryExpression(BinaryExpression exp)
        {
            string priority1 = string.Empty, priority2 = string.Empty;
            if (exp.ToString().Contains("(("))
            {
                priority1 = "(";
                priority2 = ")";
            }
            string left = DealExpress(exp.Left);
            if (exp.Left.ToString().IndexOf("IndexOf") > -1)
            {
                return left;
            }
            string oper = GetOperStr(exp.NodeType);
            string right = string.Empty;
            if (exp.Right.ToString().ToLower() == "null")
            {
                if (oper == "=")
                {
                    oper = " is null";
                }
                else
                {
                    oper = " is not null";
                }
            }
            else
            {
                right = DealExpress(exp.Right);
            }
            return priority1 + left + oper + right + priority2;
        }
        /// <summary>
        /// 访问字段或属性
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        private static string DealMemberExpression(MemberExpression exp, string Names = null)
        {
            if (exp.Expression is ConstantExpression)
            {
                var obj = (exp.Expression as ConstantExpression).Value;
                string f = obj.ToString();
                if (exp.Member is FieldInfo)
                {
                    var value = (exp.Member as FieldInfo).GetValue(obj);
                    if (value != null)
                    {
                        if (value is Array)
                        {
                            Array v = value as Array;
                            string r = string.Empty;
                            foreach (var item in v)
                            {
                                r += item.ToValStr() + ",";
                            }
                            return "(" + r.TrimEnd(',') + ")";
                        }
                        else if (value is IList)
                        {
                            IList v = value as IList;
                            string r = string.Empty;
                            foreach (var item in v)
                            {
                                r += item.ToValStr() + ",";
                            }
                            return "(" + r.TrimEnd(',') + ")";
                        }
                        else if (value is ValueType || value is String)
                        {
                            return value.ToValStr();
                        }
                        else
                        {
                            if (value.GetType().IsClass)
                            {
                                PropertyInfo propertyinfo = value.GetType().GetProperty(Names);
                                return propertyinfo.GetValue(value).ToValStr();
                            }
                            return exp.Member.Name.ToValStr();
                        }
                    }
                    else
                    {
                        return exp.Member.Name.ToValStr();
                    }

                }
                else if (exp.Member is PropertyInfo)
                {
                    var value = (exp.Member as PropertyInfo).GetValue(obj);
                    if (value != null)
                    {

                        if (value is Array)
                        {
                            Array v = value as Array;
                            string r = string.Empty;
                            foreach (var item in v)
                            {
                                r += item.ToValStr() + ",";
                            }
                            return "(" + r.TrimEnd(',') + ")";
                        }
                        else if (value is IList)
                        {
                            IList v = value as IList;
                            string r = string.Empty;
                            foreach (var item in v)
                            {
                                r += item.ToValStr() + ",";
                            }
                            return "(" + r.TrimEnd(',') + ")";
                        }
                        else if (value is ValueType || value is String)
                        {
                            return value.ToValStr();
                        }
                        else
                        {
                            if (value.GetType().IsClass)
                            {
                                PropertyInfo propertyinfo = value.GetType().GetProperty(Names);
                                return propertyinfo.GetValue(value).ToValStr();
                            }
                            return exp.Member.Name.ToValStr();
                        }
                    }
                    else
                    {
                        return exp.Member.Name.ToValStr();
                    }
                }
                else
                {
                    return exp.Member.Name;
                }

            }
            else if (exp.Expression is MemberExpression)
            {
                return DealMemberExpression(exp.Expression as MemberExpression, exp.Member.Name);
            }
            else
            {
                if (exp.NodeType == ExpressionType.MemberAccess && exp.Type.Name.ToLower() == "datetime" && exp.Member.Name == "Now")
                {
                    return "'" + DateTime.Now.ToString() + "'";
                }
                else
                {
                    return exp.Member.Name;
                }
            }
        }
        /// <summary>
        /// 条件运算符的表达式
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        private static string DealConstantExpression(ConstantExpression exp)
        {
            return exp.Value.ToValStr();
        }
        /// <summary>
        /// 一元运输符的表达式
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        private static string DealUnaryExpression(UnaryExpression exp, string symbol = null)
        {
            return DealExpress(exp.Operand, symbol);
        }
        /// <summary>
        /// 处理参数
        /// </summary>
        /// <param name="Methodexp"></param>
        /// <param name="strexp"></param>
        /// <param name="symbol"></param>
        private static void ProcessMethod(MethodCallExpression Methodexp, ref string strexp, string symbol = null)
        {
            if (Methodexp.Arguments.Count > 1)
            {
                if (Methodexp.Arguments.First() is NewArrayExpression)
                {
                    if (Methodexp.Arguments.Count == 2)
                    {
                        strexp += Methodexp.Arguments[1].DealExpress(symbol) + Methodexp.Method.Name.GetMethodToSQL(symbol) + Methodexp.Arguments[0].DealExpress(symbol);
                    }
                }
                else if (Methodexp.Arguments.First() is MemberExpression)
                {
                    if (Methodexp.Arguments.Count == 2)
                    {
                        strexp += Methodexp.Arguments[1].DealExpress(symbol) + Methodexp.Method.Name.GetMethodToSQL(symbol) + DealExpress(Methodexp.Arguments.First() as MemberExpression, symbol);
                    }
                }
                else
                {
                    foreach (var item in Methodexp.Arguments)
                    {
                        if (item is MethodCallExpression)
                        {
                            var rf = item as MethodCallExpression;
                            ProcessMethod(rf, ref strexp, symbol);
                        }
                        else
                        {
                            if (item.NodeType != ExpressionType.Constant)
                            {
                                strexp += " and " + item.DealExpress(symbol);
                            }
                        }
                    }
                }
            }
            else
            {
                if (Methodexp.Object == null)
                {
                    strexp = DealExpress(Methodexp.Arguments[0], symbol);
                }
                else
                {
                    string ModelName = Methodexp.Method.Name;
                    string GetValue = DealExpress(Methodexp.Arguments[0], symbol);
                    if (Methodexp.Object.NodeType == ExpressionType.Add)
                    {
                        var r = Methodexp.Object as BinaryExpression;
                        strexp = r.Left.DealExpress(symbol) + "+" + r.Right.DealExpress(symbol) + GetSQLExp(ModelName, GetValue.Replace("'", ""));
                    }
                    else
                    {
                        if (Methodexp.Object.Type.Name == typeof(List<>).Name)
                        {
                            strexp = GetValue + ModelName.GetMethodToSQL(symbol) + Methodexp.Object.DealExpress(symbol);
                        }
                        else
                        {
                            strexp = Methodexp.Object.DealExpress(symbol) + GetSQLExp(ModelName, GetValue.Replace("'", ""));
                        }
                    }
                }
            }
        }
        #endregion
        #region 数据转换
        /// <summary>
        /// 处理运算逻辑符
        /// </summary>
        /// <param name="methodename"></param>
        /// <param name="symbol"></param>
        /// <returns></returns>
        private static string GetMethodToSQL(this string methodename, string symbol)
        {
            switch (methodename.ToLower())
            {
                case "contains":
                    return (symbol == "!" ? " not in " : " in ");
                default:
                    return " = ";
            }
        }
        /// <summary>
        /// 获取方法表达式        
        /// </summary>
        /// <param name="modth">方法名</param>
        /// <param name="val">参数值</param>
        /// <returns></returns>
        private static string GetSQLExp(string modth, string val)
        {
            if (string.IsNullOrEmpty(modth))
            {
                return "";
            }
            else
            {
                string Modth = modth.ToLower();
                switch (Modth)
                {
                    case "contains":
                        Modth = " like '%" + val + "%'";
                        break;
                    case "endwith":
                        Modth = " like '%" + val + "'";
                        break;
                    case "startwith":
                        Modth = " like '" + val + "%'";
                        break;
                    case "indexof":
                        Modth = " like '%" + val + "%'";
                        break;
                    case "equals":
                        Modth = " = '" + val + "'";
                        break;
                    case "todatetime":
                        Modth = "'" + val + "'";
                        break;
                    default:
                        Modth = "";
                        break;
                }
                return Modth;
            }
        }
        /// <summary>
        /// 处理运算逻辑符
        /// </summary>
        /// <param name="e_type"></param>
        /// <returns></returns>
        private static string GetOperStr(ExpressionType e_type)
        {
            switch (e_type)
            {
                case ExpressionType.OrElse: return " OR ";
                case ExpressionType.Or: return "|";
                case ExpressionType.AndAlso: return " AND ";
                case ExpressionType.And: return "&";
                case ExpressionType.GreaterThan: return ">";
                case ExpressionType.GreaterThanOrEqual: return ">=";
                case ExpressionType.LessThan: return "<";
                case ExpressionType.LessThanOrEqual: return "<=";
                case ExpressionType.NotEqual: return "<>";
                case ExpressionType.Add: return "+";
                case ExpressionType.Subtract: return "-";
                case ExpressionType.Multiply: return "*";
                case ExpressionType.Divide: return "/";
                case ExpressionType.Modulo: return "%";
                case ExpressionType.Equal: return "=";
            }
            return "";
        }
        #endregion
    }
}
