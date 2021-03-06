﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace InnoTecheLearning
{
    public static partial class Utils
    {
        /// <summary>
        /// A class that provides methods to help create the UI.
        /// </summary>
        public static class Create
        {
            public static Button Button(Text Text, EventHandler OnClick, Color BackColor =
                default(Color), Color TextColor = default(Color))
            {
                if (BackColor == default(Color))
                    BackColor = Color.Silver;
                if (TextColor == default(Color))
                    TextColor = Color.Black;
                Button Button = new Button{Text = Text, TextColor = TextColor, BackgroundColor = BackColor};
                Button.Clicked += OnClick;
                return Button;
            }
            public static Button Button(Text Text, EventHandler OnClick, Size Size,
                 Color BackColor = default(Color), Color TextColor = default(Color))
            {
                if (BackColor == default(Color))
                    BackColor = Color.Silver;
                if (TextColor == default(Color))
                    TextColor = Color.Black;
                Button Button = new Button
                {
                    Text = Text,
                    TextColor = TextColor,
                    WidthRequest = Size.Width,
                    HeightRequest = Size.Height,
                    BackgroundColor = BackColor
                };
                Button.Clicked += OnClick;
                return Button;
            }
            public class ExpressionEventArgs : EventArgs
            {   public ExpressionEventArgs(Expressions Expression) : base() { this.Expression = Expression; }
                public Expressions Expression { get; } }
            public static Button Button(Expressions Expression, EventHandler<ExpressionEventArgs> OnClick, 
                Color BackColor = default(Color), Color TextColor = default(Color))
            {
                if (BackColor == default(Color))
                    BackColor = Color.Silver;
                if (TextColor == default(Color))
                    TextColor = Color.Black;
                Button Button = new Button { Text = Expression.AsString(),
                    TextColor = TextColor, BackgroundColor = BackColor };
                Button.Clicked += (object sender, EventArgs e)=> { OnClick(sender, new ExpressionEventArgs(Expression)); };
                return Button;
            }
            public static Button Button(Expressions Expression, EventHandler<ExpressionEventArgs> OnClick, 
                Size Size, Color BackColor = default(Color), Color TextColor = default(Color))
            {
                if (BackColor == default(Color))
                    BackColor = Color.Silver;
                if (TextColor == default(Color))
                    TextColor = Color.Black;
                Button Button = new Button
                {
                    Text = Expression.AsString(),
                    TextColor = TextColor,
                    WidthRequest = Size.Width,
                    HeightRequest = Size.Height,
                    BackgroundColor = BackColor
                };
                Button.Clicked += (object sender, EventArgs e) => { OnClick(sender, new ExpressionEventArgs(Expression)); };
                return Button;
            }
            public static Button Button(Expressions Expression, EventHandler<ExpressionEventArgs> OnClick,
                Text Text, Color BackColor = default(Color), Color TextColor = default(Color))
            {
                if (BackColor == default(Color))
                    BackColor = Color.Silver;
                if (TextColor == default(Color))
                    TextColor = Color.Black;
                Button Button = new Button
                {
                    Text = Text,
                    TextColor = TextColor,
                    BackgroundColor = BackColor
                };
                Button.Clicked += (object sender, EventArgs e) => { OnClick(sender, new ExpressionEventArgs(Expression)); };
                return Button;
            }
            public static Button Button(Expressions Expression, EventHandler<ExpressionEventArgs> OnClick,
                Text Text, Size Size, Color BackColor = default(Color), Color TextColor = default(Color))
            {
                if (BackColor == default(Color))
                    BackColor = Color.Silver;
                if (TextColor == default(Color))
                    TextColor = Color.Black;
                Button Button = new Button
                {
                    Text = Text,
                    TextColor = TextColor,
                    WidthRequest = Size.Width,
                    HeightRequest = Size.Height,
                    BackgroundColor = BackColor
                };
                Button.Clicked += (object sender, EventArgs e) => { OnClick(sender, new ExpressionEventArgs(Expression)); };
                return Button;
            }
            [Obsolete("Use Create.Image(ImageSource Source, Action OnTap) instead.\nDeprecated in 0.10.0a46")]
            public static Button ButtonB(FileImageSource Image, EventHandler OnClick)
            {   return ButtonB(Image, OnClick, new Size(50, 50));}
            [Obsolete("Use Create.Image(ImageSource Source, Action OnTap, Size Size) instead.\nDeprecated in 0.10.0a46")]
            public static Button ButtonB(FileImageSource Image, EventHandler OnClick, Size Size)
            {
                Button Button = new Button
                {
                    Image = Image,
                    WidthRequest = Size.Width,
                    HeightRequest = Size.Height
                };
                Button.Clicked += OnClick;
                return Button;
            }

            [Obsolete("Use MainScreenItem(ImageSource Source, Action OnTap, Label Display) instead.\nDeprecated in 0.10.0a46")]
            public static StackLayout MainScreenItemB/*B = Button*/(FileImageSource Image, EventHandler OnClick, Text Display)
            {
                return new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    VerticalOptions = LayoutOptions.StartAndExpand,
                    HorizontalOptions = LayoutOptions.Center,
                    Children = { ButtonB(Image: Image, OnClick: OnClick), Display }
                };
            }

            public static StackLayout MainScreenItem(ImageSource Source, Action OnTap, Label Display)
            {
                return new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    VerticalOptions = LayoutOptions.StartAndExpand,
                    HorizontalOptions = LayoutOptions.Center,
                    WidthRequest = 70,
                    Children = { Image(Source: Source, OnTap: OnTap), Display }
                };
            }

            public static StackLayout MainScreenRow(params StackLayout[] MainScreenItems)
            {
                StackLayout MenuScreenRow = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.StartAndExpand,
					Spacing = 50,
                    Children = { }
                };
                foreach (StackLayout MenuScreenItem in MainScreenItems)
                    MenuScreenRow.Children.Add(MenuScreenItem);
                return MenuScreenRow;
            }

            public static ImageSource Image(string FileName)
            {
                return ImageSource.FromResource(CurrentNamespace + ".Images." + FileName);
            }

            public enum ImageFile : int
            {
                Forum = 1,
                Translate = 2,
                VocabBook = 3,
                Calculator = 4,
                Calculator_Free = 5,
                Factorizer = 6,
                Sports = 7,
                MusicTuner = 8,
                MathSolver = 9,
                Cello = 10,
                Violin = 11
            }


            public static ImageSource Image(ImageFile File)
            {
                string ActualFile = "";
                switch (File)
                {
                    case ImageFile.Forum:
                        ActualFile = "forum-message-3.png";
                        break;
                    case ImageFile.Translate:
                        ActualFile = "translator-tool-3.png";
                        break;
                    case ImageFile.VocabBook:
                        ActualFile = "book-2.png";
                        break;
                    case ImageFile.Calculator:
                        ActualFile = "square-root-of-x-mathematical-signs.png";
                        break;
                    case ImageFile.Calculator_Free:
                        ActualFile = "square-root-of-x-mathematical-signs.png";
                        break;
                    case ImageFile.Factorizer:
                        ActualFile = "mathematical-operation.png";
                        break;
                    case ImageFile.Sports:
                        ActualFile = "man-sprinting.png";
                        break;
                    case ImageFile.MusicTuner:
                        ActualFile = "treble-clef-2.png";
                        break;
                    case ImageFile.MathSolver:
                        ActualFile = "japanese-dragon.png";
                        break;
                    case ImageFile.Cello:
                        ActualFile = "cello-icon.png";
                        break;
                    case ImageFile.Violin:
                        ActualFile = "violin-icon.png";
                        break;
                    default:
                        ActualFile = "";
                        break;
                }
                return Image(ActualFile);
                ;
            }
            public static Image Image(ImageFile File, Action OnTap)
            { return Image(Image(File), OnTap); }
            public static Image Image(ImageFile File, Action OnTap, Size Size)
            { return Image(Image(File), OnTap, Size); }
            public static Image ImageD/*D = Default (size)*/(ImageFile File, Action OnTap)
            { return ImageD(Image(File), OnTap); }
            public static Image ImageD/*D = Default (size)*/(ImageSource Source, Action OnTap)
            {
                Image Image = new Image{Source = Source};
                var Tap = new TapGestureRecognizer();
                Tap.Command = new Command(OnTap);
                Image.GestureRecognizers.Add(Tap);
                return Image;
            }
            public static Image Image(ImageSource Source, Action OnTap)
            {
                return Image(Source, OnTap, new Size(50, 50));
            }
            public static Image Image(ImageSource Source, Action OnTap, Size Size)
            {
                Image Image = new Image
                {
                    Source = Source,
                    WidthRequest = Size.Width,
                    HeightRequest = Size.Height
                };
                var Tap = new TapGestureRecognizer();
                Tap.Command = new Command(OnTap);
                Image.GestureRecognizers.Add(Tap);
                return Image;
            }
            public static Label BoldLabel(Text Text, Color TextColor = default(Color), 
                Color BackColor = default(Color), NamedSize Size = NamedSize.Default)
            {
                if (TextColor == default(Color))
                    TextColor = Color.Black;
                if (TextColor == default(Color))
                    TextColor = Color.Default;
                return new Label
                {
                    Text = Text,
                    FontAttributes = FontAttributes.Bold,
                    TextColor = TextColor,
                    BackgroundColor = BackColor,
                    VerticalTextAlignment = TextAlignment.Start,
                    HorizontalTextAlignment = TextAlignment.Center,
                    FontSize = Device.GetNamedSize(Size, typeof(Label)),
                    HorizontalOptions = LayoutOptions.Fill
                };
            }
            public static Label BoldLabel2(Text Text, Color TextColor = default(Color), 
                Color BackColor = default(Color), NamedSize Size = NamedSize.Default)
            {
                if (TextColor == default(Color))
                    TextColor = Color.Black;
                if (TextColor == default(Color))
                    TextColor = Color.Default;
                return new Label
                {
                    FormattedText = Format(Bold(Text)),
                    TextColor = TextColor,
                    BackgroundColor = BackColor,
                    VerticalTextAlignment = TextAlignment.Start,
                    HorizontalTextAlignment = TextAlignment.Center,
                    FontSize = Device.GetNamedSize(Size, typeof(Label)),
                    HorizontalOptions = LayoutOptions.Fill
                };
            }
            public static ScrollView Changelog
            {
                get
                {
                    var Return = new ScrollView
                    {
                        Content = new Label
                        {
                            Text = Resources.GetString("Change.log"),
                            TextColor = Color.Black,
                            LineBreakMode = LineBreakMode.WordWrap,
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            HorizontalOptions = LayoutOptions.FillAndExpand
                        },
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand
                    };
                    /*Return.SizeChanged += (object sender, EventArgs e) =>
                    {
                        var View = (View)sender;
                        if (View.Width <= 0 || View.Height <= 0) return;
                        Return.WidthRequest = View.Width; Return.HeightRequest = View.Height;
                    };*/
                    return Return;
                }
            }
            public static Label VersionDisplay
            {
                get
                {
                    return new Label
                    {
                        Text = "Version: " + VersionFull,
                        HorizontalTextAlignment = TextAlignment.End,
                        VerticalTextAlignment = TextAlignment.Start,
                        LineBreakMode = LineBreakMode.NoWrap,
                        TextColor = Color.Black
                    };
                }
            }
            public static Button Back(Page Page, Color BackColor = default(Color), Color TextColor = default(Color))
            {
                if (BackColor == default(Color))
                    BackColor = Color.Silver;
                if (TextColor == default(Color))
                    TextColor = Color.Black;
                Button Return = Button("Back", delegate { Page.SendBackButtonPressed(); }, Color.Silver);
                Return.HorizontalOptions = LayoutOptions.End;
                Return.VerticalOptions = LayoutOptions.Fill;
                return Return;
            }

            public static Button UpdateAlpha(Page Page, Color BackColor = default(Color), Color TextColor = default(Color))
            {
                if (BackColor == default(Color))
                    BackColor = Color.Silver;
                if (TextColor == default(Color))
                    TextColor = Color.Black;
                Button Return = Button("Check for Alpha", delegate
                {
#if __ANDROID__
                    Android.App.ProgressDialog progress = new Android.App.ProgressDialog(Forms.Context);
                    progress.Indeterminate = true;
                    progress.SetProgressStyle(Android.App.ProgressDialogStyle.Horizontal);
                    progress.SetMessage("Please wait... Loading updater....");
                    progress.SetCancelable(true);
                    progress.Show();
                    progress.SetMessage(new Updater((Updater.UpdateProgress Progress) =>
                    {
                        progress.SetMessage(Progress.ToName());
                        progress.Progress = Progress.Percentage() * 100;
                    }).CheckUpdate().ToString());
                    Do(System.Threading.Tasks.Task.Delay(2000));
                    progress.Dismiss();
#elif WINDOWS_UWP
                    var w = new ProgressDialog(
                        new ProgressDialogConfig { Title = "Please wait... Loading updater...." });
                    w.Show();
                    w.Title = new Updater((Updater.UpdateProgress Progress) =>
                    {
                        w.Title = Progress.ToName();
                        w.PercentComplete = Progress.Percentage();
                    }).CheckUpdate().ToString();
                    Do(System.Threading.Tasks.Task.Delay(2000));
                    w.Hide();
#else
                    Alert(Page, "Only supported on Android and Windows 10. " +
                        "For other versions, please check the github repository manually.");
#endif
                }, Color.Silver);
                Return.HorizontalOptions = LayoutOptions.End;
                Return.VerticalOptions = LayoutOptions.Fill;
                return Return;
            }
            public static StackLayout ChangelogView(Page Page, Color BackColor = default(Color))
            {
                ScrollView Changelog = Create.Changelog;
                if (BackColor == default(Color))
                    BackColor = Color.White;
                return new StackLayout
                {
                    Children = { Changelog, Back(Page) },
                    BackgroundColor = BackColor,
                    HorizontalOptions = LayoutOptions.Fill,
                    VerticalOptions = LayoutOptions.Fill
                };
            }
            public static Label Title(Text Text)
            {
                return new Label
                {
                    FontSize = 25,
                    BackgroundColor = Color.FromUint(4285098345),
                    FontAttributes = FontAttributes.Bold,
                    TextColor = Color.White,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalOptions = LayoutOptions.Start,
                    Text = Text
                };
            }
            public static Label Society
            {
                get
                {
                    return new Label
                    {
                        HorizontalTextAlignment = TextAlignment.Center,
                        TextColor = Color.Black,
                        FormattedText = Format((Text)"Developed by the\n", Bold("Innovative Technology Society of CSWCSS"))
                    };
                }
            }

            public static StackLayout Row(bool VerticalExpand, params View[] Items)
            {
                StackLayout MenuScreenRow = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = VerticalExpand ? LayoutOptions.StartAndExpand : LayoutOptions.Center,
                    Children = { }
                };
                foreach (View MenuScreenItem in Items)
                    MenuScreenRow.Children.Add(MenuScreenItem);
                return MenuScreenRow;
            }
            public static StackLayout Column(params View[] Items)
            {
                StackLayout MenuScreenRow = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.StartAndExpand,
                    Children = { }
                };
                foreach (View MenuScreenItem in Items)
                    MenuScreenRow.Children.Add(MenuScreenItem);
                return MenuScreenRow;
            }
            public static ScrollView ButtonStack(params Button[] Buttons)
            {
                StackLayout Return = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                for (int i = 0; i < Buttons.Length - 1; i++)
                    Return.Children.Add(new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children = { Buttons[i], Buttons[++i] }
                    });
                return new ScrollView
                {
                    Orientation = ScrollOrientation.Vertical,
                    Content = Return,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
            }
            public static ColumnDefinitionCollection Columns(GridUnitType Unit, params double[] Widths)
            {
                ColumnDefinitionCollection Return = new ColumnDefinitionCollection();
                foreach (int Width in Widths)
                    Return.Add(new ColumnDefinition { Width = new GridLength(Width, Unit) });
                return Return;
            }
            public static RowDefinitionCollection Rows(GridUnitType Unit, params double[] Heights)
            {
                RowDefinitionCollection Return = new RowDefinitionCollection();
                foreach (int Height in Heights)
                    Return.Add(new RowDefinition { Height = new GridLength(Height, Unit) });
                return Return;
            }
            public static Entry Entry(Text Text, Text Placeholder, Func<string> ReadOnly = null, Keyboard Keyboard = null,
                Color TextColor = default(Color), Color PlaceholderColor = default(Color), Color BackColor = default(Color))
            {
                Entry Return = new Entry
                {
                    Text = Text,
                    Placeholder = Placeholder,
                    Keyboard = Keyboard ?? Keyboard.Default,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    TextColor = TextColor == default(Color) ? Color.Black : TextColor,
                    PlaceholderColor = PlaceholderColor == default(Color) ? Color.Silver : PlaceholderColor,
                    BackgroundColor = BackColor == default(Color) ? Color.Default : BackColor
                };
                if(ReadOnly!= null) Return.TextChanged += TextChanged(ReadOnly);
                return Return;
            }
            public static Version Version(int Major, int Minor, int Build = 0, VersionStage Stage = 0, short Revision = 0)
            { return new Version(Major, Minor, Build, (int)Stage << 16 + Revision); }
        }
    }
}