<script>
    document.getElementById("searchBtn").addEventListener("click", searchProduct);
    document.getElementById("searchInput").addEventListener("keypress", function (e) {
    if (e.key === "Enter") searchProduct();
});

    function searchProduct() {
        let keyword = document.getElementById("searchInput").value.toLowerCase();
    let products = document.querySelectorAll(".product-card");
    let found = false;

    products.forEach(p => {
        let name = p.querySelector("h3").textContent.toLowerCase();
    if (name.includes(keyword)) {
        p.style.display = "block";
    found = true;
        } else {
        p.style.display = "none";
        }
    });

    let msg = document.getElementById("not-found");
    if (!found) {
        if (!msg) {
        msg = document.createElement("p");
    msg.id = "not-found";
    msg.textContent = "Không tìm thấy sản phẩm nào.";
    msg.style.color = "red";
    msg.style.marginTop = "20px";
    document.querySelector(".product-grid").appendChild(msg);
        }
    } else {
        if (msg) msg.remove();
    }
}
</script>
