<template>
    <div class="row-like">
        <div class="d-flex"><slot /></div>
    </div>
</template>
<style lang="scss">
.row-like {
    margin-left: $grid-gutter-width / -2;
    margin-right: $grid-gutter-width / -2;
}
</style>
