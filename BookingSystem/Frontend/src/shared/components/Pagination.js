import React, { Component } from "react";

class Pagination extends Component {
  getPages(totalPages, currentPage, pageSize) {
    currentPage = currentPage || 1;
    pageSize = pageSize || 10;
    var startPage, endPage;
    if (totalPages <= 10) {
      startPage = 1;
      endPage = totalPages;
    } else {
      if (currentPage <= 6) {
        startPage = 1;
        endPage = 10;
      } else if (currentPage + 4 >= totalPages) {
        startPage = totalPages - 9;
        endPage = totalPages;
      } else {
        startPage = currentPage - 5;
        endPage = currentPage + 4;
      }
    }

    var pages = [...Array(endPage + 1 - startPage).keys()].map(
      i => startPage + i
    );
    return pages;
  }

  render() {
    const { setPage, pageInfo } = this.props;
    const { page, pageSize, totalPages } = pageInfo;
    const currentPage = page;
    var pages = this.getPages(totalPages, page, pageSize);
    // if (!pages || pages.length < 2) {
    //   return null;
    // }
    return (
      <div className="container">
        <nav>
          <ul className="pagination">
            <li className={"page-item " + (currentPage === 1 ? "active" : "")}>
              <a className="page-link" onClick={() => setPage(1)}>
                First
              </a>
            </li>
            <li
              className={"page-item " + (currentPage === 1 ? "disabled" : "")}
            >
              <a className="page-link" onClick={() => setPage(currentPage - 1)}>
                Prev
              </a>
            </li>
            {pages.map((page, index) => (
              <li
                key={index}
                className={
                  "page-item " + (currentPage === page ? "active" : "")
                }
              >
                <a className="page-link" onClick={() => setPage(page)}>
                  {page}
                </a>
              </li>
            ))}
            <li
              className={
                "page-item " + (currentPage === totalPages ? "disabled" : "")
              }
            >
              <a className="page-link" onClick={() => setPage(currentPage + 1)}>
                Next
              </a>
            </li>
            <li
              className={
                "page-item " + (currentPage === totalPages ? "disabled" : "")
              }
            >
              <a className="page-link" onClick={() => setPage(totalPages)}>
                Last
              </a>
            </li>
          </ul>
        </nav>
      </div>
    );
  }
}

export { Pagination };
