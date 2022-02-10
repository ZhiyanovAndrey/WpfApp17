using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp17
{
    /// <summary>
    /// Логика взаимодействия для Указатель_цвета.xaml
    /// </summary>
    public partial class Указатель_цвета : UserControl
    {
        public static DependencyProperty ColorProperty; //создаем свойствF зависимости
        public static DependencyProperty RedProperty;
        public static DependencyProperty GreenProperty;
        public static DependencyProperty BlueProperty;

        static Указатель_цвета()
        {
            // Регистрация свойств зависимости
            ColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(Указатель_цвета),
                new FrameworkPropertyMetadata(Colors.Black, new PropertyChangedCallback(OnColorChanged)));
            RedProperty = DependencyProperty.Register("Red", typeof(byte), typeof(Указатель_цвета),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));
            GreenProperty = DependencyProperty.Register("Green", typeof(byte), typeof(Указатель_цвета),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));
            BlueProperty = DependencyProperty.Register("Blue", typeof(byte), typeof(Указатель_цвета),
                 new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));
        }

        /*Теперь, определив свойства зависимости, можно добавить стандартные оболочки для свойств,
        которые облегчают доступ к ним и обеспечивают возможность обращения из XAML-разметки
        оболочки свойств не должны содержать никакой логики, поскольку свойства могут устанавливаться и 
        извлекаться непосредственно с помощью методов SetValue() и GetValue() базового класса DependencyObject*/
        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
        public byte Red
        {
            get { return (byte)GetValue(RedProperty); }
            set { SetValue(RedProperty, value); }
        }
        public byte Green
        {
            get { return (byte)GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); }
        }
        public byte Blue
        {
            get { return (byte)GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); }
        }
        public Указатель_цвета()
        {
            InitializeComponent();
        }


        /*логика синхронизации свойств в данном примере реализуется с использованием обратных вызовов, 
         * которые инициируются при изменении свойств через их оболочки, либо при прямом вызове SetValue().

           Обратные вызовы изменения свойств отвечают за сохранение соответствия свойства Color текущим значениям Red, Green и Blue. 
        Всякий раз, когда изменяется свойство Red, Green или Blue, свойство Color тоже соответствующим образом модифицируется:*/
        private static void OnColorRGBChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            Указатель_цвета colorPicker = (Указатель_цвета)sender;
            Color color = colorPicker.Color;
            if (e.Property == RedProperty)
                color.R = (byte)e.NewValue;
            else if (e.Property == GreenProperty)
                color.G = (byte)e.NewValue;
            else if (e.Property == BlueProperty)
                color.B = (byte)e.NewValue;

            colorPicker.Color = color;
        }
        private static void OnColorChanged(DependencyObject sender,
      DependencyPropertyChangedEventArgs e)
        {
            Color newColor = (Color)e.NewValue;
            Указатель_цвета colorpicker = (Указатель_цвета)sender;
            colorpicker.Red = newColor.R;
            colorpicker.Green = newColor.G;
            colorpicker.Blue = newColor.B;
        }
    }
}
