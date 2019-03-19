export const handleError = function(response) {
  console.log(response);
  if (!response.ok) {
    throw Error(response.status);
  }
  return response;
};
