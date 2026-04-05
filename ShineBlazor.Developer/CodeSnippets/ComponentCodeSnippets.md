# ShineBlazor Components - Code Snippets Guide

This document contains code snippets for all ShineBlazor components based on the demo pages.

---

## Table of Contents
1. [Alert](#alert)
2. [AppBar](#appbar)
3. [Badge](#badge)
4. [Button](#button)
5. [Card](#card)
6. [Carousel](#carousel)
7. [Accordion & Collapse](#accordion--collapse)
8. [DataGrid](#datagrid)
9. [Drawer](#drawer)
10. [DropDown](#dropdown)
11. [FlexBox](#flexbox)
12. [Form Controls](#form-controls)
13. [InfiniteScroll](#infinitescroll)
14. [ListGroup & ListView](#listgroup--listview)
15. [Modal](#modal)
16. [ProgressBar](#progressbar)
17. [RangeDial](#rangedial)
18. [PropertyGrid](#propertygrid)
19. [Animations](#animations)

---

## Alert

### Basic Alert with Color
```razor
<Alert Color="Color.Primary">
    <i class="bi bi-exclamation-circle-fill align-text-top"></i>
    This is a primary alert with link.
</Alert>
```

### Dismissible Alert
```razor
<Alert Color="Color.Danger" Dismissible="true" @bind-Show="_show">
    This is a dismissible alert.
</Alert>

@code {
    private bool _show = true;
}
```

### Alert with DropDown Color Selection
```razor
<div class="row">
    <div class="col-6">
        <Alert Color="_color.Value">
            <i class="bi bi-exclamation-circle-fill align-text-top"></i>
            This is <a class="alert-link">@_color</a> alert with link.
        </Alert>
    </div>
    <div class="col-6">
        <DropDown TItem="KeyValuePair<string, Color>"
                  Items="Color.Values"
                  SelectedItem="_color" 
                  SelectedItemChanged="ColorChanged"
                  SelectionMode="SelectionMode.Single" 
                  ItemToText="t => t.Key">
        </DropDown>
    </div>
</div>

@code {
    private KeyValuePair<string, Color> _color;

    private void ColorChanged(KeyValuePair<string, Color> color)
    {
        _color = color;
        InvokeAsync(StateHasChanged);
    }
}
```

---

## AppBar

### Basic Navigation Bar
```razor
<AppBar BrandHref="/"
        BrandContent="BrandContent"
        Class="mb-3 text-bg-info"
        Expand="navbar-expand-lg"
        Placement="sticky-top">
    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
        <li class="nav-item">
            <a class="nav-link active" aria-current="page" href="#">Home</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" href="#">About</a>
        </li>
        <li class="nav-item dropdown">
            <DropDown TItem="string" SelectionMode="SelectionMode.None">
                <TriggerContent>
                    <span class="nav-link">More</span>
                </TriggerContent>
                <ChildContent>
                    <li><a class="dropdown-item">Settings</a></li>
                    <li><a class="dropdown-item">Profile</a></li>
                </ChildContent>
            </DropDown>
        </li>
    </ul>
    <Badge Value="20" BackgroundColor="Color.Danger"></Badge>
</AppBar>

@code {
    private RenderFragment BrandContent => __builder =>
    {
        <span>Shine Blazor</span>
    };
}
```

---

## Badge

### Badge with Headings
```razor
<h1>Example heading <Badge Value="New" /></h1>
<h2>Example heading <Badge Value="New" /></h2>
<h3>Example heading <Badge Value="New" /></h3>
```

### Badge with Background Colors
```razor
<Badge Value="Primary" Background="Color.Primary" class="me-1" />
<Badge Value="Secondary" Background="Color.Secondary" class="me-1" />
<Badge Value="Success" Background="Color.Success" class="me-1" />
<Badge Value="Danger" Background="Color.Danger" class="me-1" />
<Badge Value="Warning" Background="Color.Warning" class="me-1" />
<Badge Value="Info" Background="Color.Info" class="me-1" />
<Badge Value="Light" Background="Color.Light" class="me-1" />
<Badge Value="Dark" Background="Color.Dark" class="me-1" />
```

### Pill Badges
```razor
<Badge Value="Primary" Background="Color.Primary" class="rounded-pill me-1" />
<Badge Value="Success" Background="Color.Success" class="rounded-pill me-1" />
<Badge Value="Danger" Background="Color.Danger" class="rounded-pill me-1" />
<Badge Value="Warning" Background="Color.Warning" class="rounded-pill me-1" />
<Badge Value="Info" Background="Color.Info" class="rounded-pill me-1" />
```

---

## Button

### Basic Button Styles
```razor
<Button Variant="BtnVariant.Default" Color="Color.Primary">Button</Button>
<Button Variant="BtnVariant.Outlined" Color="Color.Success">Outlined</Button>
<Button Variant="BtnVariant.Text" Color="Color.Danger">Text</Button>
```

### Button with Size Options
```razor
<Button Variant="BtnVariant.Default" Color="Color.Primary" Size="BtnSize.Small">Small</Button>
<Button Variant="BtnVariant.Default" Color="Color.Primary" Size="BtnSize.Medium">Medium</Button>
<Button Variant="BtnVariant.Default" Color="Color.Primary" Size="BtnSize.Large">Large</Button>
```

### Interactive Button
```razor
<Button Variant="BtnVariant.Default"
        Color="Color.Primary"
        Clicked="@(() => ToastService.AddToast("Button Clicked", Color.Info))"
        Disabled="@_disable">
    Click Me!
</Button>
<InputControl @bind-Value="@_disable" Label="Disable button"></InputControl>

@code {
    private bool _disable = false;
    
    [Inject]
    private ToastService ToastService { get; set; }
}
```

---

## Card

### Basic Card
```razor
<Card>
    <svg class="card-img-top" width="100%" height="180">
        <rect width="100%" height="100%" fill="#868e96"></rect>
        <text x="50%" y="50%" fill="#dee2e6" dy=".3em">Image</text>
    </svg>
    <CardBody>
        <Text Typo="Typography.h5" Class="card-title">Card title</Text>
        <Text Class="card-text">
            It is a long established fact that a reader will be 
            distracted by the readable content of a page when looking at its layout.
        </Text>
    </CardBody>
</Card>
```

### Card with Header and Footer
```razor
<Card>
    <CardHeader>
        Featured
    </CardHeader>
    <CardBody>
        <Text Typo="Typography.h5" Class="card-title">Card title</Text>
        <Text Class="card-text">
            It is a long established fact that a reader will be
            distracted by the readable content of a page when looking at its layout.
        </Text>
    </CardBody>
    <CardFooter>
        <Button Variant="BtnVariant.Default" Color="Color.Primary">Click</Button>
    </CardFooter>
</Card>
```

### Card with Glass Variant
```razor
<div class="row p-3" style="background: url(/images/demo_bg.jpg) center;">
    <div class="col-6">
        <Card GlassVariant="true">
            <CardBody>
                <Text Typo="Typography.h5" Class="card-title">Card title</Text>
                <Text Class="card-text">
                    It is a long established fact that a reader will be
                    distracted by the readable content of a page when looking at its layout.
                </Text>
            </CardBody>
        </Card>
    </div>
</div>
```

### Card with Utilities
```razor
<div class="row">
    <div class="col-md-6">
        <Card class="text-center">
            <CardBody>
                <Text Typo="Typography.h5" Class="card-title">Centered Card</Text>
                <Text Class="card-text">
                    This card uses <code>text-center</code> utility for center-aligned text.
                </Text>
                <Button Variant="BtnVariant.Default" Color="Color.Success">Action</Button>
            </CardBody>
        </Card>
    </div>
    <div class="col-md-6">
        <Card class="bg-primary text-white">
            <CardBody>
                <Text Typo="Typography.h5" Class="card-title">Primary Card</Text>
                <Text Class="card-text">
                    This card uses <code>bg-primary</code> and <code>text-white</code> utilities.
                </Text>
                <Button Variant="BtnVariant.Default" Color="Color.Light">Action</Button>
            </CardBody>
        </Card>
    </div>
</div>
```

---

## Carousel

### Basic Carousel
```razor
<Carousel Interval="3" Class="text-center">
    <CarouselItem>
        <div class="container text-bg-primary py-5">
            <h1><b>Slide 1</b></h1>
            <h1><i>Lorem ipsum</i></h1>
        </div>
    </CarouselItem>
    <CarouselItem>
        <div class="container text-bg-info py-5">
            <h1><b>Slide 2</b></h1>
            <h1><i>Lorem ipsum</i></h1>
        </div>
    </CarouselItem>
    <CarouselItem>
        <div class="container text-bg-warning py-5">
            <h1><b>Slide 3</b></h1>
            <h1><i>Lorem ipsum</i></h1>
        </div>
    </CarouselItem>
</Carousel>
```

---

## Accordion & Collapse

### Accordion Item
```razor
<AccordionItem>
    <HeaderContent>
        <div class="text-bg-primary flex-grow-1 p-2">Click to Toggle</div>
    </HeaderContent>
    <ChildContent>
        <FlexBox Class="border border-dark-subtle p-3" BackgroundColor="Color.Light">
            Lorem ipsum dolor sit amet...
        </FlexBox>
    </ChildContent>
</AccordionItem>
```

### Multiple Accordion Items
```razor
<Accordion>
    <AccordionItem>
        <HeaderContent>
            Header Accordion 1
        </HeaderContent>
        <ChildContent>
            Lorem ipsum dolor sit amet...
        </ChildContent>
    </AccordionItem>
    <AccordionItem>
        <HeaderContent>
            Header Accordion 2
        </HeaderContent>
        <ChildContent>
            Lorem ipsum dolor sit amet...
        </ChildContent>
    </AccordionItem>
</Accordion>
```

---

## DataGrid

### Basic DataGrid
```razor
<DataGrid ItemsProvider="DummyDataProvider.GetFruits" Class="shadow-sm">
    <Columns>
        <DataGridColumn TItem="Data.FruitData" TValue="string" Name="Id" Header="ID" DataExpression="x => x.Id" CanSort="true" />
        <DataGridColumn TItem="Data.FruitData" TValue="string" Name="Name" Header="Name" DataExpression="x => x.Name" CanSort="true" />
        <DataGridColumn TItem="Data.FruitData" TValue="string" Name="Price" Header="Price (CAD)" DataExpression="x => x.Price" CanSort="true" />
        <DataGridColumn TItem="Data.FruitData" TValue="string" Name="Quantity" Header="Quantity" DataExpression="x => x.Quantity" CanSort="true" />
    </Columns>
</DataGrid>

@code {
    [Inject]
    private DummyDataProvider DummyDataProvider { get; set; }
}
```

---

## Drawer

### Basic Drawer (Left Side)
```razor
<DrawerContainer Class="border">
    <LeftDrawer>
        <Drawer Position="DrawerPosition.Left"
                Width="18rem"
                CollapsedWidth="5rem"
                HasShadow="true"
                TriggerPosition="TriggerPosition.Top">
            <ChildContent>
                <NavMenu IsVertical="true" Class="pa-2">
                    <NavigationItems>
                        <NavigationItem Class="active">
                            <i class="bi bi-house-door" />
                            <span class="menu-text">Home</span>
                        </NavigationItem>
                        <NavigationItem>
                            <i class="bi bi-person" />
                            <span class="menu-text">Profile</span>
                        </NavigationItem>
                        <NavigationItem>
                            <i class="bi bi-gear" />
                            <span class="menu-text">Settings</span>
                        </NavigationItem>
                    </NavigationItems>
                </NavMenu>
            </ChildContent>
        </Drawer>
    </LeftDrawer>
    <Content>
        <div class="p-4">
            <h4>Main Content Area</h4>
            <p>
                This is the main content area. The drawer on the left can be collapsed or expanded.
            </p>
        </div>
    </Content>
</DrawerContainer>
```

### Drawer on Right Side
```razor
<DrawerContainer Class="border">
    <Content>
        <div class="p-4">
            <h4>Main Content Area</h4>
            <p>
                The drawer appears on the right side in this example.
            </p>
        </div>
    </Content>
    <RightDrawer>
        <Drawer Position="DrawerPosition.Right"
                @bind-Collapsed="_rightCollapsed"
                Width="16rem"
                CollapsedWidth="3.5rem"
                Class="text-bg-dark"
                TriggerPosition="TriggerPosition.None">
            <ExpandedContent>
                <!-- Drawer content when expanded -->
            </ExpandedContent>
        </Drawer>
    </RightDrawer>
</DrawerContainer>

@code {
    private bool _rightCollapsed = false;
}
```

---

## DropDown

### DropDown Menu
```razor
<DropDown TItem="Data.FruitData" Items="DummyDataProvider.GetFruits(4, 0)"
        ItemClicked="FruitClicked" ItemToText="f => f.Name">
    <TriggerContent>
        <div class="btn btn-info">Menu</div>
    </TriggerContent>
</DropDown>

@code {
    [Inject]
    private DummyDataProvider DummyDataProvider { get; set; }
    
    [Inject]
    private ToastService Toasts { get; set; }

    private void FruitClicked(Data.FruitData item)
    {
        Toasts.AddToast($"{item.Name} clicked.", Color.Info);
    }
}
```

### Single Selection DropDown
```razor
<div style="width:12rem">
    <DropDown TItem="Data.FruitData" Items="DummyDataProvider.GetFruits(4, 0)"
            SelectionMode="SelectionMode.Single" ItemToText="f => f.Name">
    </DropDown>
</div>

@code {
    [Inject]
    private DummyDataProvider DummyDataProvider { get; set; }
}
```

### Multi Selection DropDown
```razor
<div style="width:16rem">
    <DropDown TItem="Data.FruitData" Items="DummyDataProvider.GetFruits(4, 0)"
              SelectionMode="SelectionMode.Multiple" ItemToText="f => f.Name"
              @bind-SelectedItems="@_selectedFruits">
        <TriggerContent>
            <input type="text" value="@(_selectedFruits.Count) Items" class="form-select form-control-small" readonly />
        </TriggerContent>
    </DropDown>
</div>

@code {
    private ICollection<Data.FruitData> _selectedFruits = new HashSet<Data.FruitData>();
}
```

---

## FlexBox

### FlexBox Row Layout
```razor
<FlexBox Row="true" Gap="FlexGap.Gap_2">
    <div class="p-3 bg-primary text-white rounded">Item 1</div>
    <div class="p-3 bg-secondary text-white rounded">Item 2</div>
    <div class="p-3 bg-success text-white rounded">Item 3</div>
</FlexBox>
```

### FlexBox with Alignment
```razor
<FlexBox Row="true" Gap="FlexGap.Gap_3" AlignItems="FlexAlign.ItemsCenter" JustifyContent="FlexJustify.Between" style="height: 100px;">
    <div class="p-2 bg-primary text-white rounded">Start</div>
    <div class="p-2 bg-success text-white rounded">Center</div>
    <div class="p-2 bg-danger text-white rounded">End</div>
</FlexBox>
```

### FlexBox with Wrap
```razor
<FlexBox Row="true" Gap="FlexGap.Gap_2" Wrap="FlexWrap.Wrap" style="max-width: 400px;">
    <div class="p-2 bg-primary text-white rounded" style="width: 180px;">Wide 1</div>
    <div class="p-2 bg-secondary text-white rounded" style="width: 180px;">Wide 2</div>
    <div class="p-2 bg-success text-white rounded" style="width: 180px;">Wide 3</div>
</FlexBox>
```

### FlexBox Fill
```razor
<FlexBox Row="true" Gap="FlexGap.Gap_2" FlexFill="true">
    <div class="p-2 bg-info text-white rounded">Fill 1</div>
    <div class="p-2 bg-warning text-dark rounded">Fill 2</div>
    <div class="p-2 bg-danger text-white rounded">Fill 3</div>
</FlexBox>
```

### FlexBox Column Layout
```razor
<FlexBox Gap="FlexGap.Gap_3" AlignItems="FlexAlign.ItemsCenter">
    <div class="p-2 bg-primary text-white rounded">Column 1</div>
    <div class="p-2 bg-success text-white rounded">Column 2</div>
    <div class="p-2 bg-danger text-white rounded">Column 3</div>
</FlexBox>
```

---

## Form Controls

### Form with Multiple Input Types
```razor
<EditForm Model="@_formModel">
    <FormControl Label="User Name" InputType="InputType.Text" Placeholder="User name" @bind-Value="@_formModel.UserName" />
    <FormControl Label="Password" InputType="InputType.Password" Placeholder="Password" @bind-Value="@_formModel.Password" />
    <FormControl Label="Date Of Birth" InputType="InputType.Date" @bind-Value="@_formModel.DateOfBirth" />
    <FormControl Label="Age" InputType="InputType.Number" @bind-Value="@_formModel.Age" />
    <CheckboxControl Label="Keep logged in" Switch="true" @bind-Value="_formModel.KeepLoggedIn" Text="@(_formModel.KeepLoggedIn ? "Yes" : "No")" />
    <RadioControl Label="Gender" Items="RadioOptions" @bind-Value="_formModel.Gender" />
</EditForm>

@code {
    private FormModel _formModel = new FormModel();
    private string[] RadioOptions = new string[] { "Male", "Female", "X" };

    private class FormModel {
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public bool KeepLoggedIn { get; set; }
    }
}
```

### InputControl for Various Types
```razor
<div class="row mb-3">
    <div class="col">Number: </div>
    <div class="col"><InputControl @bind-Value="_number" /></div>
    <div class="col"><Text>Current Value: @_number</Text></div>
</div>
<div class="row mb-3">
    <div class="col">Text: </div>
    <div class="col"><InputControl @bind-Value="_text" /></div>
    <div class="col"><Text>Current Value: @_text</Text></div>
</div>
<div class="row mb-3">
    <div class="col">Decimal: </div>
    <div class="col"><InputControl @bind-Value="_float" /></div>
    <div class="col"><Text>Current Value: @_float</Text></div>
</div>
<div class="row mb-3">
    <div class="col">DateTime: </div>
    <div class="col"><InputControl @bind-Value="_dateTime" /></div>
    <div class="col"><Text>Current Value: @_dateTime</Text></div>
</div>

@code {
    private int _number = 0;
    private string _text = "Edit text";
    private double _float = 0;
    private DateTime? _dateTime;
}
```

---

## InfiniteScroll

### Infinite Scrolling Example
```razor
<Text>Items: @_itemsCount</Text>
<div class="scroll-view row">
    <InfiniteScroll TItem="Data.FruitData" ErrorHandler="HandleError"
                    ItemsProvider="DummyDataProvider.GetFruits"
                    ItemsCountChanged="HandleItemsCountChanged">
        <ItemTemplate>
            <div class="col-4">
                <KeyValueTable TValue="string" TableTitle="@($"Fruit: {context.Name}")"
                                Bordered="true" Striped="true" Class="table-sm">
                    <ChildContent>
                        <KeyValueTableRow Key="ID">
                            @context.Id
                        </KeyValueTableRow>
                        <KeyValueTableRow Key="Name">
                            @context.Name
                        </KeyValueTableRow>
                        <KeyValueTableRow Key="Price">
                            @context.Price
                        </KeyValueTableRow>
                        <KeyValueTableRow Key="Quantity">
                            @context.Quantity
                        </KeyValueTableRow>
                    </ChildContent>
                </KeyValueTable>
            </div>
        </ItemTemplate>
    </InfiniteScroll>
</div>

@code {
    private int _itemsCount = 0;

    [Inject]
    private DummyDataProvider DummyDataProvider { get; set; }

    [Inject]
    private ToastService ToastService { get; set; }

    private void HandleError(Exception ex)
    {
        ToastService.AddToast("Error: " + ex.Message, Color.Danger);
    }

    private void HandleItemsCountChanged(int count)
    {
        _itemsCount = count;
        InvokeAsync(StateHasChanged);
    }
}
```

---

## ListGroup & ListView

### List Group - Simple
```razor
<ListGroup Items="DummyDataProvider.GetFruits(5, 0)" ItemToText="t => t.Name"/>
```

### List Group - Custom Template
```razor
<ListGroup Items="DummyDataProvider.GetFruits(5, 0)">
    <ItemTemplate>
        <li class="list-group-item">
            <div class="d-flex align-items-center" style="gap: 5px;">
                <span>@context.Name</span>
                <Badge BackgroundColor="Color.Danger" Value="@context.Quantity" />
                <div class="flex-grow-1"></div>
                <span><i class="bi bi-currency-dollar mr-1"></i>@context.Price</span>
            </div>
        </li>
    </ItemTemplate>
</ListGroup>
```

### List View
```razor
<div class="row">
    <div class="col-4">
        <ListView Items="DummyDataProvider.GetFruits(5, 0)"
                  TextVariant="@TextVariant" Size="@Size.Value"
                  Color="SelectedColor.Value" ItemToText="f => f.Name" />
    </div>
</div>

@code {
    private KeyValuePair<string, Color> SelectedColor { get; set; }
    private bool TextVariant { get; set; }
    private KeyValuePair<string, ListViewSize> Size { get; set; }
}
```

### List View - Custom Template
```razor
<ListView Items="DummyDataProvider.GetFruits(5, 0)"
          TextVariant="@TextVariant" Color="SelectedColor.Value" Size="@Size.Value">
    <ItemTemplate>
        <a href="#" class="d-flex">
            <Text>@context.Name</Text>
            <span class="flex-grow-1" />
            <Text>@context.Price</Text>
        </a>
    </ItemTemplate>
</ListView>
```

---

## Modal

### Basic Modal Dialog
```razor
<Button Variant="BtnVariant.Default" Color="Color.Primary" Clicked="ShowModal">
    Show Modal
</Button>
<Modal @bind-Show="_showModal">
    <Header>Header content.</Header>
    <Body>
        <FlexBox>
            Lorem ipsum dolor sit amet...
        </FlexBox>
    </Body>
    <Footer>
        This is footer.
    </Footer>
</Modal>

@code {
    private bool _showModal = false;

    private void ShowModal()
    {
        _showModal = true;
    }
}
```

---

## ProgressBar

### Progress Bar with Different Colors
```razor
<FlexBox Gap="FlexGap.Gap_2">
    <ProgressBar ProgressValue="25" Color="Color.Primary" />
    <ProgressBar ProgressValue="50" Color="Color.Success" />
    <ProgressBar ProgressValue="75" Color="Color.Info" />
    <ProgressBar ProgressValue="100" Color="Color.Warning" ShowProgress="true" />
    <ProgressBar ProgressValue="60" Color="Color.Danger" />
</FlexBox>
```

### Striped Progress Bar
```razor
<FlexBox Gap="FlexGap.Gap_2">
    <ProgressBar ProgressValue="10" Color="Color.Primary" IsStriped="true" />
    <ProgressBar ProgressValue="25" Color="Color.Success" IsStriped="true" />
    <ProgressBar ProgressValue="50" Color="Color.Info" IsStriped="true" />
    <ProgressBar ProgressValue="75" Color="Color.Warning" IsStriped="true" />
    <ProgressBar ProgressValue="100" Color="Color.Danger" IsStriped="true" />
</FlexBox>
```

### Animated Striped Progress Bar
```razor
<ProgressBar ProgressValue="75" Color="Color.Primary" IsStriped="true" Animated="true" />
```

### Custom Height Progress Bar
```razor
<FlexBox Gap="FlexGap.Gap_2">
    <ProgressBar ProgressValue="25" Color="Color.Success" ShowProgress="true" Height="2rem" />
    <ProgressBar ProgressValue="75" Color="Color.Danger" Height="2px" />
</FlexBox>
```

---

## RangeDial

### Range Dial with Color Variant
```razor
<FlexBox AlignItems="FlexAlign.ItemsCenter">
    <RangeDial TValue="int" Variant="ProgressVariant.Color" Size="150"
               @bind-Value="_valueColor">
    </RangeDial>
</FlexBox>

@code {
    private int _valueColor = 10;
}
```

### Range Dial with Gradient Variant
```razor
<FlexBox AlignItems="FlexAlign.ItemsCenter">
    <RangeDial TValue="int" Variant="ProgressVariant.Gradient" Size="150"
               ShowValue="false" @bind-Value="_valueGradient">
        <Alert Color="@GetColor(_valueGradient)" Class="p-2">
            @_valueGradient
        </Alert>
    </RangeDial>
</FlexBox>

@code {
    private int _valueGradient = 50;

    private Color GetColor(int value)
    {
        return value > 66 ? Color.Danger : (value < 33 ? Color.Success : Color.Warning);
    }
}
```

### Flat Range Dial
```razor
<FlexBox AlignItems="FlexAlign.ItemsCenter">
    <RangeDial TValue="int" Variant="ProgressVariant.Color"
               Size="150" Flat="true" @bind-Value="@_valueFlat">
    </RangeDial>
</FlexBox>

@code {
    private int _valueFlat = 30;
}
```

---

## PropertyGrid

### Basic PropertyGrid
```razor
<div class="row">
    <div class="col">
        <PropertyGrid @bind-Value="@_formModel" PropertyChanged="() => InvokeAsync(StateHasChanged)"></PropertyGrid>
    </div>
    <div class="col">
        <KeyValueTable TValue="string" TableTitle="Result"
                       Bordered="true" Striped="true" Class="table-sm mt-1">
            <KeyValueTableRow Key="User Name">
                @_formModel.Name
            </KeyValueTableRow>
            <KeyValueTableRow Key="Date Of Birth">
                @(_formModel.DateOfBirth.HasValue ? _formModel.DateOfBirth.Value.ToString() : string.Empty)
            </KeyValueTableRow>
            <KeyValueTableRow Key="Age">
                @_formModel.Age
            </KeyValueTableRow>
        </KeyValueTable>
    </div>
</div>

@code {
    private FormModel _formModel = new FormModel();

    private class FormModel {
        [DisplayName("User Name")]
        public string Name { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int? Age { get; set; }
    }
}
```

### PropertyGrid with Collections
```razor
<PropertyGrid @bind-Value="@_shoppingCart" PropertyChanged="() => InvokeAsync(StateHasChanged)"></PropertyGrid>

@code {
    private ShoppingCart _shoppingCart = new ShoppingCart();

    private class ShoppingCart {
        [DisplayName("Items")]
        public Item[] Items { get; set; }

        [DisplayName("Coupons")]
        public List<Coupon> Coupons { get; set; }
    }

    private class Item {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    private class Coupon {
        public string Code { get; set; }
        public decimal Price { get; set; }
    }
}
```

---

## Animations

### Flashing Component
```razor
<FlexBox Row="true" AlignItems="FlexAlign.ItemsStart" Class="mb-3">
    <DropDown TItem="KeyValuePair<string, FlashVariant>"
              Items="FlashVariant.Values"
              @bind-SelectedItem="_variant"
              Label="Variant" Variant="InputVariant.Outlined"
              SelectionMode="SelectionMode.Single" 
              ItemToText="t => t.Key">
    </DropDown>
    <DropDown TItem="KeyValuePair<string, Color>" Items="Color.Values"
              @bind-SelectedItem="_color"
              Label="Color" Variant="InputVariant.Outlined"
              SelectionMode="SelectionMode.Single"
              ItemToText="t => t.Key">
    </DropDown>
    <InputControl TValue="int" @bind-Value="_interval" Required="true"
                  Label="Interval (sec)" Variant="InputVariant.Outlined">
    </InputControl>
</FlexBox>
<FlashingComponent Variant="_variant.Value" Color="_color.Value"
                    Class="p-2" Interval="@($"{_interval}s")">
    Flashing Div
</FlashingComponent>

@code {
    private KeyValuePair<string, FlashVariant> _variant;
    private KeyValuePair<string, Color> _color;
    private int _interval = 1;
}
```

### Flashing CSS Animation
```razor
<FlexBox Row="true">
    <div class="p-2 mb-2 flash-background" style="--flash-color: var(--bs-danger);--flash-interval: 2s;">
        Flashing background div
    </div>

    <div class="p-2 mb-2 text-bg-success flash-opacity" style="--flash-interval: 2s;">
        Flashing opacity div
    </div>
    <div class="p-2 mb-2 flash-shadow" style="--flash-color: var(--bs-warning);--flash-interval: 2s;">
        Flashing shadow div
    </div>
</FlexBox>
```

### Animation Transforms
```razor
<FlexBox AlignItems="FlexAlign.ItemsCenter" JustifyContent="FlexJustify.Center" Gap="FlexGap.Gap_2">
    <div class="@GetAnimationCss(Animation.Horizontal)"
         style="@CssStyleBuilder.Create().WithHorizontalTransform("-1rem", "1s", AnimationTimingFunction.EaseInOut).Build()">
        Animate Horizontal
    </div>
    <div class="@GetAnimationCss(Animation.Vertical)"
         style="@CssStyleBuilder.Create().WithVerticalTransform("-1rem", "0.5s", AnimationTimingFunction.EaseIn).Build()">
        Animate Vertical
    </div>
    <div class="@GetAnimationCss(Animation.Scale)"
         style="@CssStyleBuilder.Create().WithScaleTransform("1.25", "1.25", "0.5s", AnimationTimingFunction.EaseIn).Build()">
        Animate Scale
    </div>
    <div class="@GetAnimationCss(Animation.Rotate)"
         style="@CssStyleBuilder.Create().WithRotateTransform("30deg", "1s", AnimationTimingFunction.EaseIn).Build()">
        Animate Rotate
    </div>
</FlexBox>

@code {
    private string GetAnimationCss(Animation animation)
    {
        // Use CssClassBuilder to apply animation classes
        return CssClassBuilder.Create()
            .UseAnimation(animation)
            .Build();
    }
}
```

---

## Common Patterns

### Using ToastService
```csharp
@code {
    [Inject]
    private ToastService ToastService { get; set; }

    private void ShowNotification()
    {
        ToastService.AddToast("Success!", Color.Success);
    }
}
```
