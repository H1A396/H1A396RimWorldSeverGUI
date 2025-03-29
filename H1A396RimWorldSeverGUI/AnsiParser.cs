using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace H1A396RimWorldSeverGUI
{
    public class AnsiParser
    {

        // 匹配ANSI转义码的正则表达式（\x1B代表ESC字符）
        private static readonly Regex AnsiRegex = new Regex(
            @"\x1B\[([^m]*)m",
            RegexOptions.Compiled // 编译正则提高性能
        );




        // 解析入口方法
        public static void Parse(string input, Action<string, Color> textHandler)
        {
            // 获取所有ANSI代码匹配项
            var matches = AnsiRegex.Matches(input);
            int lastIndex = 0; // 记录上次处理位置
            Color currentColor = Color.Silver; // 默认颜色

            foreach (Match match in matches)
            {
                // 处理匹配前的普通文本
                if (match.Index > lastIndex)
                {
                    textHandler?.Invoke(
                        input.Substring(lastIndex, match.Index - lastIndex),
                        currentColor
                    );
                }

                // 解析颜色代码
                var code = match.Groups[1].Value; // 获取转义码内容（如"31;42"）
                currentColor = ParseAnsiCode(code, currentColor);

                lastIndex = match.Index + match.Length; // 更新处理位置
            }

            // 处理剩余文本
            if (lastIndex < input.Length)
            {
                textHandler?.Invoke(input.Substring(lastIndex), currentColor);
            }
        }



        // ANSI代码转Color对象
        private static Color ParseAnsiCode(string code, Color current)
        {
            if (string.IsNullOrEmpty(code)) return current;

            var parts = code.Split(';'); // 分割多代码（如"1;31"）
            foreach (var part in parts)
            {
                if (!int.TryParse(part, out var codeValue)) continue;

                switch (codeValue)
                {
                    case 0:  // 重置样式
                        return Color.Silver;
                    case 31: // 红色
                        return Color.Red;
                    case 32: // 绿色
                        return Color.LimeGreen;
                    // 其他颜色代码...
                    default:
                        return current; // 未处理代码保持当前颜色
                }
            }
            return current;
        }
    }




}

