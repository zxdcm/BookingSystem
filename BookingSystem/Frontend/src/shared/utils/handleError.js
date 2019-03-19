export const handleError = function(response) {
  if (!response.ok) {
    throw Error(response.status);
  }
  return response;
};
