   M S B A M L   `   `   `  ����R  NMiracle.Desktop.Toolkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Miracle.Desktop.Toolkit.Controls Miracle.Desktop.Toolkit.Controls  5      R NMicrosoft.Windows.Shell, Version=3.0.1.0, Culture=neutral, PublicKeyToken=nullbFclr-namespace:Microsoft.Windows.Shell;assembly=Microsoft.Windows.ShellMicrosoft.Windows.Shell 5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source3    -Miracle.Desktop.Toolkit.Controls.ModernDialog �� 
TargetType �� Property   WindowBackgroundContent �� Value  DefaultFontFamily  DefaultFontSize  
WindowText&   System.Windows.Media.TextOptions �� 
TargetType  WindowBackground  WindowBorder    BackgroundContent 
 Accent
 �� Top �� Left	 � RowDefinitions
 � Title � DataContext   TextFormattingMode  ToUpperConverter �� 	ConverterB   <Miracle.Desktop.Toolkit.Controls.TransitioningContentControl    Buttons �� Orientation  WindowBorderActive �� RelativeSource �� AncestorType  	 BooleanToVisibilityConverter*  $Microsoft.Windows.Shell.WindowChrome   CornerRadius   GlassFrameThickness�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      ;controls.clr-namespace:Miracle.Desktop.Toolkit.Controls  5      PshellFclr-namespace:Microsoft.Windows.Shell;assembly=Microsoft.Windows.Shell  5        5      �� 5   
   $; 5/Miracle.Desktop.Toolkit;component/Assets/Button.xaml?�6   �� 5   
   $? 9/Miracle.Desktop.Toolkit;component/Assets/Converters.xaml?�6   %�  '         7  7 	 �� 5      "   6   .�5   
   ��  �@  BackgroundContent# �   6.   �� 5   
    � ��# �  6'   �� 5   
    � ��# �  6%   �� 5   
    � ��# �  6'   �� 5   
    � ��$	 640��6%   �� 5   
    � ��$	 640��6&   �� 5   
    � ��$	 240��6%   �� 5   
    � ��$	 240��6&   �� 5   
    �@�ShowInTaskbar .  6*   �� 5   
    �@�
ResizeMode$ NoResize=�6'   �� 5   
    �@�UseLayoutRounding . 6.   �� 5   
    �@ TextFormattingMode$ Display=�6;   �� 5   
    � �� 5      �� 5      "   6"   .R�5      �� #���  6   $��0q�6M   ._�5      � .+�5      �� #���  6%   $��1q�6R   ._�5    "   �� .u�5!   &   � .+�5#   *   �� #��z 69   �� 5&   *   .+�5'   .   �� #���  68   $ 18��6X   $ 24��6h   $	��100��6y   $��6��6�   5(   +   � 5*   *   $��24q�6/   
���  ��	 5+   .   �� 5,   2   $
��Auto �6@   �� 5-   2   $��* �6@   �� 5.   2   $
��Auto �6@   .+�52   .   �� # z
 68   $��Segoe UI)�53   4   $��24(�54   4   $ Ideal=�55   4   $��CharacterEllipsis=�56   4   ��52   ^   �� 8   56   4     59   .   $��1��6S   $��0,20,0,0q�6`   #��z��6r   �� 5<   .   $��2��6;   #��z 6H   $��Right=�6p   ��5=   2   �� 5>   6   .R�5?   :   �� $ 
Horizontal=�6E   5@   7   5B   /   5D   +   5E   '   5F   #   5G      �� 5H      #���  6%   $��1q�6X   y�6l   �� *
IsActive+ �� *FindAncestor+" �8  5I      5J      5K      5M      �� 5O   
    �@ WindowChrome 5P        5Q      $ 0��6%   $ 1q�66   5S      5T      5V      