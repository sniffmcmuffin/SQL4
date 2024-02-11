using Infrastructure.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class RoleService(RoleRepository roleRepository)
{
    private readonly RoleRepository _roleRepository = roleRepository;

    // Create
    public RoleEntity CreateRole(string roleName)
    {
        var roleEntity = _roleRepository.Get(x => x.RoleName == roleName);
        roleEntity ??= _roleRepository.Create(new RoleEntity { RoleName = roleName });

        return roleEntity;
    }

    public async Task<RoleEntity> CreateRoleAsync(string roleName)
    {
        var roleEntity = await _roleRepository.GetAsync(x => x.RoleName == roleName);

        if (roleEntity == null)
        {
            roleEntity = await _roleRepository.CreateAsync(new RoleEntity { RoleName = roleName });
        }

        return roleEntity;
    }


    // Read
    public RoleEntity GetRoleByRoleName(string roleName) // By name
    {
        var roleEntity = _roleRepository.Get(x => x.RoleName == roleName);
        return roleEntity;
    }

    public RoleEntity GetRoleByRoleId(int id) // By Id
    {
        var roleEntity = _roleRepository.Get(x => x.Id == id);
        return roleEntity;
    }

    public IEnumerable<RoleEntity> GetRoles()
    {
        var roles = _roleRepository.GetAll();
        return roles;
    }

    // Update
    public RoleEntity UpdateRole(RoleEntity roleEntity)
    {
        var updatedRoleEntity = _roleRepository.Update(x => x.Id == roleEntity.Id, roleEntity);
        return updatedRoleEntity;
    }

    // Delete
    public void DeleteRole(int id) // Ändra till bool när jag lägger till checkar.
    {
        _roleRepository.Delete(x => x.Id == id);
    }
}
