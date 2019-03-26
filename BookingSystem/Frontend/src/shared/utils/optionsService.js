class OptionsService {
  static getEmptyOption() {
    return [
      {
        value: "",
        label: ""
      }
    ];
  }

  static getNumericOptions(max = 20) {
    return Array.from(new Array(max), (val, index) => ({
      label: index + 1,
      value: index + 1
    }));
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
