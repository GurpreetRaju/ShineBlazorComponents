# ShineBlazor Components - Quick Reference

A quick lookup guide for all ShineBlazor components with minimal code examples.

## Table of Contents
- [Alert](#alert)
- [AppBar](#appbar)
- [Badge](#badge)
- [Button](#button)
- [Card](#card)
- [Carousel](#carousel)
- [Accordion](#accordion)
- [DataGrid](#datagrid)
- [Drawer](#drawer)
- [DropDown](#dropdown)
- [FlexBox](#flexbox)
- [Form Controls](#form-controls)
- [InfiniteScroll](#infinitescroll)
- [ListGroup](#listgroup)
- [Modal](#modal)
- [ProgressBar](#progressbar)
- [RangeDial](#rangedial)
- [PropertyGrid](#propertygrid)
- [Animations](#animations)

---

## Alert
Display contextual feedback messages.

```razor
<Alert Color="Color.Primary">Alert message</Alert>
<Alert Color="Color.Danger" Dismissible="true" @bind-Show="_show">Dismissible alert</Alert>
```

**Key Properties**: `Color`, `Dismissible`, `Show`

---

## AppBar
Navigation bar at the top of the page.

```razor
<AppBar BrandHref="/" Class="text-bg-primary">
    <ul class="navbar-nav"><li><a href="#">Home</a></li></ul>
</AppBar>
```

**Key Properties**: `BrandHref`, `BrandContent`, `Class`, `Expand`, `Placement`

---

## Badge
Small count and labeling component.

```razor
<Badge Value="New" Background="Color.Primary" />
<Badge Value="5" Background="Color.Danger" class="rounded-pill" />
```

**Key Properties**: `Value`, `Background`, `class`

---

## Button
Interactive button with multiple variants.

```razor
<Button Variant="BtnVariant.Default" Color="Color.Primary" Clicked="OnClick">Click Me</Button>
<Button Size="BtnSize.Large" Disabled="true">Large Disabled</Button>
```

**Key Properties**: `Variant`, `Color`, `Size`, `Clicked`, `Disabled`

---

## Card
Container component for grouping content.

```razor
<Card>
    <CardHeader>Title</CardHeader>
    <CardBody>Content</CardBody>
    <CardFooter>Footer</CardFooter>
</Card>
```

**Key Properties**: `GlassVariant`, `class`

---

## Carousel
Slideshow for cycling through content.

```razor
<Carousel Interval="3">
    <CarouselItem>Slide 1</CarouselItem>
    <CarouselItem>Slide 2</CarouselItem>
</Carousel>
```

**Key Properties**: `Interval`, `class`

---

## Accordion
Collapsible content sections.

```razor
<Accordion>
    <AccordionItem>
        <HeaderContent>Section</HeaderContent>
        <ChildContent>Content</ChildContent>
    </AccordionItem>
</Accordion>
```

**Key Properties**: None (use child components)

---

## DataGrid
Display and sort tabular data.

```razor
<DataGrid ItemsProvider="LoadData">
    <Columns>
        <DataGridColumn TItem="Item" Header="Name" DataExpression="x => x.Name" CanSort="true" />
        <DataGridColumn TItem="Item" Header="Price" DataExpression="x => x.Price" CanSort="true" />
    </Columns>
</DataGrid>
```

**Key Properties**: `ItemsProvider`, `Columns`

---

## Drawer
Side navigation drawer.

```razor
<DrawerContainer>
    <LeftDrawer>
        <Drawer Position="DrawerPosition.Left" Width="18rem">Navigation</Drawer>
    </LeftDrawer>
    <Content>Main content</Content>
</DrawerContainer>
```

**Key Properties**: `Position`, `Width`, `CollapsedWidth`, `Collapsed`

---

## DropDown
Selection dropdown component.

```razor
<DropDown TItem="string" Items="new[]{'A','B','C'}" SelectionMode="SelectionMode.Single" />
<DropDown TItem="string" Items="new[]{'A','B','C'}" SelectionMode="SelectionMode.Multiple" @bind-SelectedItems="_items" />
```

**Key Properties**: `Items`, `SelectionMode`, `SelectedItem`, `SelectedItems`

---

## FlexBox
Flexible box layout component.

```razor
<FlexBox Row="true" Gap="FlexGap.Gap_2" AlignItems="FlexAlign.ItemsCenter">
    <div>Item 1</div>
    <div>Item 2</div>
</FlexBox>
```

**Key Properties**: `Row`, `Gap`, `AlignItems`, `JustifyContent`, `Wrap`, `FlexFill`

---

## Form Controls
Input and validation components.

```razor
<EditForm Model="@model">
    <FormControl Label="Name" InputType="InputType.Text" @bind-Value="@model.Name" />
    <CheckboxControl Label="Accept" @bind-Value="@model.Accept" />
    <RadioControl Label="Gender" Items="new[]{'M','F'}" @bind-Value="@model.Gender" />
</EditForm>
```

**Key Properties**: `Label`, `InputType`, `Value`, `Placeholder`

---

## InfiniteScroll
Load data as user scrolls.

```razor
<InfiniteScroll TItem="Item" ItemsProvider="LoadMore">
    <ItemTemplate>
        <div>@context.Name</div>
    </ItemTemplate>
</InfiniteScroll>
```

**Key Properties**: `ItemsProvider`, `ErrorHandler`

---

## ListGroup
Display a list of items.

```razor
<ListGroup Items="items" ItemToText="x => x.Name" />
<ListGroup Items="items">
    <ItemTemplate><li class="list-group-item">@context.Name</li></ItemTemplate>
</ListGroup>
```

**Key Properties**: `Items`, `ItemToText`

---

## Modal
Dialog component for user interaction.

```razor
<Modal @bind-Show="_show">
    <Header>Title</Header>
    <Body>Content</Body>
    <Footer>Footer</Footer>
</Modal>

@code { private bool _show; }
```

**Key Properties**: `Show`, `HeaderText`, `CloseButton`

---

## ProgressBar
Progress indication component.

```razor
<ProgressBar ProgressValue="25" Color="Color.Primary" />
<ProgressBar ProgressValue="50" Color="Color.Success" IsStriped="true" Animated="true" />
```

**Key Properties**: `ProgressValue`, `Color`, `IsStriped`, `Animated`, `Height`

---

## RangeDial
Circular range input dial.

```razor
<RangeDial TValue="int" Variant="ProgressVariant.Color" Size="150" @bind-Value="_value" />
@code { private int _value = 50; }
```

**Key Properties**: `Variant`, `Size`, `Value`, `ShowValue`, `Flat`

---

## PropertyGrid
Edit complex object properties.

```razor
<PropertyGrid @bind-Value="@_object" PropertyChanged="@OnChanged" />
@code { 
    private MyClass _object = new();
    private void OnChanged() { InvokeAsync(StateHasChanged); }
}
```

**Key Properties**: `Value`, `PropertyChanged`

---

## Animations
Visual effects and animations.

```razor
<FlashingComponent Variant="FlashVariant.Background" Color="Color.Primary" Interval="1s">Content</FlashingComponent>

<div class="flash-background" style="--flash-color: var(--bs-primary); --flash-interval: 2s;">Flashing</div>
```

**Key Properties**: `Variant`, `Color`, `Interval`

---

## Common Parameters

| Parameter | Description | Example |
|-----------|-------------|---------|
| `Color` | Color enumeration | `Color.Primary` |
| `@bind-Value` | Two-way binding | `@bind-Value="@model.Property"` |
| `Clicked` | Click event handler | `Clicked="@OnClick"` |
| `Items` | Collection of items | `Items="list"` |
| `ItemToText` | Item display selector | `ItemToText="x => x.Name"` |
| `Class` | CSS class string | `Class="mt-3 mb-2"` |
| `style` | Inline CSS styles | `style="color: red;"` |
| `@attributes` | Additional attributes | `@attributes="AdditionalAttributes"` |

---

## Dependency Injection

Common injected services:

```csharp
[Inject] private ToastService ToastService { get; set; }
[Inject] private DummyDataProvider DummyDataProvider { get; set; }
```

---

## Required Imports

Add to `_Imports.razor`:

```razor
@using ShineBlazor.Components
@using ShineBlazor.Components.Services
@using ShineBlazor.Components.Base
@using ShineBlazor.Components.Form
@using ShineBlazor.Components.PropertyGrid
@using ShineBlazor.Components.DataGrid
```

---

## Quick Tips

✅ Use `@bind-` for two-way binding
✅ Use `Clicked` for button click events
✅ Use `SelectionMode.Single` for one item, `Multiple` for many
✅ All colors use `Color` enum
✅ Use `class` parameter for Bootstrap classes
✅ Use `style` parameter for inline CSS
✅ Components support `@attributes` for additional parameters

---

## Layout Example

```razor
<Page PageName="Example">
    <Card>
        <CardHeader>Component Demo</CardHeader>
        <CardBody>
            <FlexBox Row="true" Gap="FlexGap.Gap_2">
                <div class="col">
                    <Button Color="Color.Primary" Clicked="@OnClick">Action</Button>
                </div>
                <div class="col">
                    <DropDown TItem="string" Items="options" SelectionMode="SelectionMode.Single" />
                </div>
            </FlexBox>
        </CardBody>
    </Card>
</Page>
```

---

**For complete examples and more details, see `ComponentCodeSnippets.md`**
