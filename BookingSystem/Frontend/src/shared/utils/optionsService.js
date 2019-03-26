class OptionsService {
  static getEmptyOption() {
    return [
      {
        value: "",
        label: ""
      }
    ];
  }

  static getOptions(options, labelProperty, valueProperty = null) {
    if (!valueProperty) {
      valueProperty = labelProperty;
    }

    let selectEntries = this.getEmptyOption();
    const valueMap = [];
    if (options) {
      options.forEach(obj => {
        const value = obj[valueProperty];
        if (!valueMap[value]) {
          valueMap[value] = true;
          selectEntries.push({
            value,
            label: obj[labelProperty]
          });
        }
      });
    }

    return selectEntries;
  }

  static getFilteredOptions(
    options,
    filterProp,
    filterValue,
    labelProp,
    labelValue
  ) {
    if (!options) {
      return [];
    }
    let filteredList = options.filter(obj => obj[filterProp] === filterValue);
    return this.getOptions(filteredList, labelProp, labelValue);
  }
}

export { OptionsService };
