# Type and Namespace Structure

## View Models

- BaseViewModel (_ObservableObject_)
  - ChildContentViewModel
    - ExternalLinkViewModel
    - ModalDialogViewModel
    - TableViewModel
    - TableHeadViewModel
    - TableBodyViewModel
    - TableFootViewModel
    - TooltipViewModel
  - ContentViewModel
    - AppearanceViewModel
      - CardViewModel
      - DismissOptionsViewModel
        - NotificationViewModel
          - AlertViewModel
          - ToastViewModel
    - RouteViewModel
      - AddNewButtonViewModel
      - EditLinkViewModel
      - GoBackLinkViewModel
  - HyperlinkViewModel
  - PaginationViewModel
  - TextWithIconViewModel
  - TextWithIconAndLinkViewModel
  - WaitIndicatorViewModel
_EOF_