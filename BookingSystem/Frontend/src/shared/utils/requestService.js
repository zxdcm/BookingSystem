import { config } from "../settings/config";

const RequestMethod = {
  GET: "GET",
  POST: "POST",
  PUT: "PUT",
  DELETE: "DELETE"
};

class OptionsBuilder {
  constructor() {
    this.options = {};
  }

  addAuth(token = null, tokenType = "Bearer") {
    if (token == null) {
      return this;
    }
    return this.addHeader("Authorization", `${tokenType} ${token}`);
  }

  addMethod(method) {
    this.options = { ...this.options, method: method };
    return this;
  }

  addHeader(header, value) {
    this.options = {
      ...this.options,
      headers: { ...this.options.headers, [header]: value }
    };
    return this;
  }

  addBody(body, formatter = JSON.stringify) {
    this.options = {
      ...this.options,
      body: formatter(body)
    };
    return this;
  }

  build() {
    return this.options;
  }
}
class RequestOptions {
  static createGetOptions(token = null) {
    return new OptionsBuilder()
      .addMethod(RequestMethod.GET)
      .addAuth(token)
      .build();
  }

  static createPostOptions(body, token = null) {
    return new OptionsBuilder()
      .addMethod(RequestMethod.POST)
      .addBody(body)
      .addAuth(token)
      .build();
  }

  static createPutOptions(body, token = null) {
    return new OptionsBuilder()
      .addMethod(RequestMethod.PUT)
      .addBody(body)
      .addAuth(token)
      .build();
  }

  static createDeleteOptions(body, token = null) {
    return new OptionsBuilder()
      .addMethod(RequestMethod.DELETE)
      .addBody(body)
      .addAuth(token)
      .build();
  }
}

class RequestService {
  static request(url, options) {
    return fetch(config.basePath + url, options);
  }

  static get(url, token = null) {
    const options = RequestOptions.createGetOptions(token);
    return RequestService.request(url, options);
  }

  static post(url, body, token = null) {
    const options = RequestOptions.createPostOptions(body, token);
    return RequestService.request(url, options);
  }

  static put(url, body, token = null) {
    const options = RequestOptions.createPutOptions(body, token);
    return RequestService.request(url, options);
  }

  static delete(url, body, token = null) {
    const options = RequestOptions.createDeleteOptions(body, token);
    return RequestService.request(url, options);
  }
}

export { RequestService };
