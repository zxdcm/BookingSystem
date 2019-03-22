const buildQuery = data =>
  Object.keys(data)
    .filter(key => data[key] != null)
    .map(key => [key, data[key]].map(encodeURIComponent).join("="))
    .join("&");

export { buildQuery };
