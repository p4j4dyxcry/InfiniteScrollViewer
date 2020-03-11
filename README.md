# InfiniteScrollViewer
WPF の無限スクロールビューアーのシンプルな実装です。

## 実装経緯
標準のScrollViewerでは負の座標や幅や高さがCanvasをオーバーラップしてしまっている場合に正しく動作しません。
この無限スクロールビューアーではCanvas等サイズが決まっているコントロールを範囲外までスクロールさせることができます。
標準のScrollViewerでは実現が難しかったのでCustomControlとして作成しました。
このコントールは元々[TsNode](https://github.com/p4j4dyxcry/TsNode)で作成したものですが別の用途でも利用したいことがあったので一般化させています。

## プラットフォーム
.NET Core 3.1 / .NET FrameWork 4.6.2

## 動作仕様
- マウスホイールで縦スクロール
- Shift + マウスホイールで横スクロール
- Ctrl + マウスホイールでマウス中心拡大

## 組み込み方法
[Exampls/MainWindow.xaml](https://github.com/p4j4dyxcry/InfiniteScrollViewer/blob/master/InfiniteScrollViewer/Example/MainWindow.xaml)
が最小限の組み込み実装サンプルです。
1. InfiniteScrollViewerはカスタムコントールですのでResourceをインポートする必要があります。
```xml
    <Window.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="pack://application:,,,/InfiniteScrollViewer;component/Style.xaml" />
            </ResourceDictionary.MergedDictionaries>            
        </ResourceDictionary>
    </Window.Resources>
```

2. InfiniteScrollViewerをxamlに記述し、ViewRect プロパティを設定します。
このViewRectにCanvasに配置されているコンテンツの最小の座標と、幅、高さを指定します。(Bindingを利用すると良い)
サンプルでは範囲が分かりやすくするためにCanvasサイズを指定して背景をレンダリングしていますがこれは本来不要です。
```xml
    <infiniteScrollViewer:InfiniteScrollViewer ViewRect="-200,-200,1224,1520">
        <Canvas Width="1024" Height="1024" Background="Gray">
            <Ellipse Canvas.Top="-200" Canvas.Left="-200" Width="100" Height="100" Fill="Red"/>
            <Ellipse Canvas.Top="70" Canvas.Left="70" Width="150" Height="150" Fill="Blue"/>
            <Ellipse Canvas.Top="1200" Canvas.Left="500" Width="120" Height="120" Fill="Red"/>
        </Canvas>
    </infiniteScrollViewer:InfiniteScrollViewer>
```

## スクリーンショット
- [TsNode](https://github.com/p4j4dyxcry/TsNode)の組み込み事例
![](https://github.com/p4j4dyxcry/InfiniteScrollViewer/blob/master/InfiniteScrollViewer/ScreenShot/sample02.gif)

---

- Examplsの動作です。
![](https://github.com/p4j4dyxcry/InfiniteScrollViewer/blob/master/InfiniteScrollViewer/ScreenShot/sample01.gif)

## License
MIT
